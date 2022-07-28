using API.DTOs.Clinic;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController:ControllerBase
    {
        private readonly IBaseRepository<Clinic> _context;
        private readonly IMapper _mapper;

        public ClinicController(IBaseRepository<Clinic> context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        [HttpPost]
        [Authorize(policy: "Doctor")]
        public ActionResult AddClinic([FromBody]ClinicDto clinicDto)
        {
            Clinic clinic = _mapper.Map<Clinic>(clinicDto);
            _context.AddAsync(clinic);

            return Ok("Created");
        }

        [HttpGet]
        public async Task<IReadOnlyList<Clinic>> GetClinics()
        {
            return await _context.GetAllAsync();
        }


    }
}
