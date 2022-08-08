using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WeekDays
    {
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Day { get; set; }

        // Navigator Props

        [ForeignKey("Center")]
        public Guid CenterId { get; set; }
        public virtual Center Center { get; set; }

        [ForeignKey("Clinic")]
        public Guid ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

    }
}
