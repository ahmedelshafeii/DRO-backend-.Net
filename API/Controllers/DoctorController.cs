using API.DTOs.Doctor;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Patient> _userManager;
        private readonly IBaseRepository<Doctor> _context;

        public DoctorController(IMapper mapper,
            UserManager<Patient> userManager
            , IBaseRepository<Doctor> context
            )
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._context = context;
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


            Patient user = await _userManager.FindByNameAsync(doctor.User.UserName);


            _context.AddAsync(new Doctor
            {
                Title = registerDto.Title,
                Department = registerDto.Department,
                UserId = user.Id
            });
           
            return Ok("Created Successfully");
        }

    }
}
