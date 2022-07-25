using Microsoft.AspNetCore.Identity;


namespace Core.Entities
{
    public class Patient : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }

    }
}
