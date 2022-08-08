using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Center_doctor
    {
        [ForeignKey("Center")]
        public Guid CenterId { get; set; }

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        public double FEE { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Center Center { get; set; }

    }
}
