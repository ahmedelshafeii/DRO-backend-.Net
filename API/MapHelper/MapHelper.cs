using API.DTOs.Patient;
using AutoMapper;
using Core.Entities;

namespace API.MapHelper
{
    public class MapHelper:Profile
    {
        public MapHelper()
        {
            CreateMap<PatientRegisterDto,Patient>();
        }

    }
}
