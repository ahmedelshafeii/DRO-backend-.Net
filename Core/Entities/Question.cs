using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Question
    {

        public Guid Id { get; set; }
        public DateTime dateTime { get; set; }
        [Column(TypeName ="varchar(20)")]
        public string Speciality { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string QuestionString { get; set; }


        // Navigation Props

        [ForeignKey("User")]
        public string PatientId { get; set; }
        public virtual User User { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}
