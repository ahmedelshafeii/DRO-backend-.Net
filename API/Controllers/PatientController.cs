
using API.DTOs.Patient;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _context;
        private readonly UserManager<Patient> _userManager;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository context,UserManager<Patient> userManager,IMapper mapper)
        {
            this._userManager = userManager;
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Patient>>> Patients()
        {
            return Ok(await _context.GetAllAsync());
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(PatientRegisterDto registerDto)
        {
            //Patient patient = new Patient()
            //{
            //    FirstName = registerDto.FirstName,
            //    MiddleName = registerDto.MiddleName,
            //    LastName = registerDto.LastName,
            //    UserName = registerDto.UserName,
            //    Email = registerDto.Email,
            //    Gender = registerDto.Gender
            //};

            Patient patient = _mapper.Map<Patient>(registerDto);


            var creationResult = await _userManager.CreateAsync(patient,registerDto.Password);

            if (!creationResult.Succeeded)
            {
                foreach(var i in creationResult.Errors)
                {
                    ModelState.AddModelError(i.Code,i.Description);
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

    }
}
