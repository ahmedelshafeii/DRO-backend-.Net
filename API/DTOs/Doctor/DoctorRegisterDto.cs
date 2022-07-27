using API.DTOs.Patient;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Doctor
{
    public class DoctorRegisterDto
    {
        
        public string Title { get; set; }
        public string Department { get; set; }
        public PatientRegisterDto User { get; set; }
    }
}
