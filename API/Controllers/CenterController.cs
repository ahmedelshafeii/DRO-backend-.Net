using API.DTOs.Center;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenterController:ControllerBase
    {
        private readonly ICenterRepository _baseContext;
        private readonly IMapper _mapper;
        public CenterController(ICenterRepository baseRepository,
            IMapper mapper)
        {
            this._baseContext = baseRepository;
            this._mapper = mapper;
        }

        [HttpGet("all")]
        public  ActionResult GetCenters()
        {
            var centers = _baseContext.getCenters();

           IReadOnlyList<CenterDto> centersDto =  _mapper.Map<IReadOnlyList<CenterDto>>(centers);

            return Ok(centersDto);
        }

        [HttpGet]
        public ActionResult GetCenter(Guid id)
        {

            Center center = _baseContext.getCenter(id);
            if(center == null) 
                return BadRequest("Something Wrong!");
           CenterDto centerDto =  _mapper.Map<CenterDto>(center);

            return Ok(centerDto);
            
        }

        [HttpPost]
        public ActionResult CreateCenter([FromBody]AddCenterDTO centerDTO)
        {
            Center center = new Center
            {
                Name = centerDTO.Name,
                Address = centerDTO.Address,
                DocAdminId = centerDTO.DocAdminId
            };
            _baseContext.AddAsync(center);

            return CreatedAtAction("GetCenter",new {id = center.Id},center);
        }

        [HttpPost("Phone")]
        public ActionResult AddCenterPhone([FromBody] CenterPhoneDto centerPhoneDto)
        {
            CenterPhone centerPhone = new CenterPhone
            {
                CenterId = centerPhoneDto.CenterId,
                Phone = centerPhoneDto.Phone
            };

            try
            {

            _baseContext.AddPhone(centerPhone);
            }
            catch
            {
                return BadRequest("Something Wrong!");
            }


            return Ok("Added Successfully!");
        }

        [HttpPost("Speciality")]
        public ActionResult AddCenterSpeciality([FromBody] CenterSpecialityDto centerSpecialityDto)
        {
            CenterSpeciality centerSpeciality = new CenterSpeciality
            {
                CenterId = centerSpecialityDto.CenterId,
                Speciality = centerSpecialityDto.Speciality
            };
            try
            {
                _baseContext.AddSpeciality(centerSpeciality);
            }
            catch
            {
                return BadRequest("Something Wrong!");
            }
           
            return Ok("Created");
        }




        /// Center [ speciality - insurance - phone ]
        ///Create
        ///Update
        ///Delete
        ///Get All
        ///Get Clinic(id)

    }
}
