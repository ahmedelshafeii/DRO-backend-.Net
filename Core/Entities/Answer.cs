using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Answer
    {
        public DateTime dateTime { get; set; }
        public string AnswerString { get; set; }

        //Navigator Props
        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
