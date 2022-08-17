using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Review
{
    public class Review
    {
        public string ReviewString { get; set; }
        [Range(0, 5)]
        public int? Rate { get; set; }

        public DateTime DateTime { get; set; }

        //Navigator Props
        [ForeignKey("User")]
        public string PatientId { get; set; }
        public virtual User User { get; set; }
    }
}
