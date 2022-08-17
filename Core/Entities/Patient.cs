using Microsoft.AspNetCore.Identity;


namespace Core.Entities
{
    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }

        // Navigator Props
        public virtual IEnumerable<Question> Questions {get; set;}


    }
}
