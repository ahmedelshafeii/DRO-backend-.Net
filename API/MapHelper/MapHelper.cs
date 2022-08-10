using API.DTOs.Center;
using API.DTOs.Clinic;
using API.DTOs.Doctor;
using API.DTOs.Patient;
using AutoMapper;
using Core.Entities;

namespace API.MapHelper
{
    public class MapHelper:Profile
    {
        public MapHelper()
        {
            CreateMap<PatientRegisterDto,User>();
            CreateMap<DoctorRegisterDto, Doctor>();
            CreateMap<ClinicDto, Clinic>();
            CreateMap<Center, CenterDto>()
                .ForMember(i=>i.Center_Phones,x=>x.MapFrom(x=>x.Center_Phones.Select(i=>i.Phone)))
                .ForMember(i=>i.Center_Doctors,x=>x.MapFrom(i=>i.Center_Doctors.Select(i=>i.DoctorId)))
                .ForMember(i=>i.Center_Insurances,
                x=>x.MapFrom(y=>y.Center_Insurances.Select(z=>z.InsuranceCompany)))
                .ForMember(i=>i.Center_Specialities,x=>x.MapFrom(i=>i.Center_Specialities.Select(i=>i.Speciality)))
                //.ForMember(i=>i.Center_WeekDays,x=>x.MapFrom(i=>i.Center_WeekDays.Select(c=>c.Day)))
                ;

        }


    }
}
