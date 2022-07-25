using Microsoft.AspNetCore.Identity;


namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        //public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        

    }
}
