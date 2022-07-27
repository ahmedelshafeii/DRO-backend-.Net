
using API.DTOs.Patient;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _context;
        private readonly UserManager<Patient> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PatientController(IPatientRepository context,
            UserManager<Patient> userManager,IMapper mapper,
            IConfiguration config)
        {
            this._userManager = userManager;
            this._context = context;
            this._mapper = mapper;
            this._config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Patient>>> Patients()
        {
            return Ok(await _context.GetAllAsync());
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(PatientRegisterDto registerDto)
        {
           
            Patient patient = _mapper.Map<Patient>(registerDto);


            var creationResult = await _userManager.CreateAsync(patient,registerDto.Password);

            if (!creationResult.Succeeded)
            {
                foreach(var error in creationResult.Errors)
                {
                    ModelState.AddModelError(error.Code,error.Description);
                }
                return BadRequest(ModelState);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,"Patient"),
                new Claim(ClaimTypes.Email,registerDto.Email),
                new Claim(ClaimTypes.Name,registerDto.UserName)
            };

            await _userManager.AddClaimsAsync(patient, claims);

            return Ok("Created Successfully");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(PatientLoginDto loginDto)
        {
            Patient patient = await _userManager.FindByNameAsync(loginDto.UserName);
            if (patient == null) return BadRequest("Not Found");

            if (await _userManager.IsLockedOutAsync(patient)) return BadRequest("Try Again Later");

            bool res = await _userManager.CheckPasswordAsync(patient,loginDto.Password);
            if (!res)
            {
                await _userManager.AccessFailedAsync(patient);
                return BadRequest("Wrong password");
            }

            var claims = await _userManager.GetClaimsAsync(patient);

            var key = _config.GetValue<string>("Key");
            var keyInBytes = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var securedKey = new SigningCredentials(keyInBytes, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"Server",
                audience:"backend",
                claims: claims,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials:securedKey
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {Token= tokenString, exp= DateTime.Now.AddMinutes(15)});            

        }

    }
}
