using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Patient
{
    public class PatientRegisterDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="password don't match")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }

    }
}
