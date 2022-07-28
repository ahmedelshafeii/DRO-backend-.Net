using API.DTOs;
using API.DTOs.Doctor;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IBaseRepository<Doctor> _context;
        private readonly IConfiguration _config;

        public DoctorController(IMapper mapper,
            UserManager<User> userManager,
            IBaseRepository<Doctor> context,
            IConfiguration config
            )
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._context = context;
            this._config = config;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(DoctorRegisterDto registerDto)
        {
            Doctor doctor = _mapper.Map<Doctor>(registerDto);

            var res = await _userManager.CreateAsync(doctor.User,registerDto.User.Password);
            if (!res.Succeeded)
            {
                foreach(var error in res.Errors)
                {
                    ModelState.AddModelError(error.Code,error.Description);
                }
                return BadRequest(ModelState);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,"Doctor"),
                new Claim(ClaimTypes.Email,doctor.User.Email),
                new Claim(ClaimTypes.Name,doctor.User.UserName)
            };

            await _userManager.AddClaimsAsync(doctor.User,claims);


            User user = await _userManager.FindByNameAsync(doctor.User.UserName);


            _context.AddAsync(new Doctor
            {
                Title = registerDto.Title,
                Department = registerDto.Department,
                UserId = user.Id
            });
           
            return Ok("Created Successfully");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            User user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null) return BadRequest("User Not Found");
            if (await _userManager.IsLockedOutAsync(user)) return BadRequest("Try Later"); 
            if(!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                await _userManager.AccessFailedAsync(user);
                return BadRequest("Wrong Password!");
            }


            var claims = await _userManager.GetClaimsAsync(user);
            var role = claims[0].Value;

            if (role != "Doctor") return Unauthorized("You are not a doctor");

            var key = _config.GetValue<string>("Key");
            var keyInBytes = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var securedKey = new SigningCredentials(keyInBytes,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer:"server",
                audience:"backend",
                claims:claims,
                signingCredentials: securedKey,
                expires:DateTime.Now.AddMinutes(15)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return Ok(new {Token=tokenString, Exp= DateTime.Now.AddMinutes(15), Role = role});
        }

    }
}
