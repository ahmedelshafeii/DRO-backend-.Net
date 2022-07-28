using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Clinic
    {
        public Guid Id { get; set; }
        [Required]
        public string clinicName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        
        [Required]
        public double FEE { get; set; }

        //Navigator Properties
        [Required]
        [ForeignKey("Doctor")]

        public Guid DocId { get; set; }
        public virtual Doctor Doctor { get; set; }


    }
}
