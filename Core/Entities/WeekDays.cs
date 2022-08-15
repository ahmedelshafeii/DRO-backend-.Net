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

        [Column(TypeName = "varchar(10)")]
        public string StartTime { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string EndTime { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Day { get; set; }

        // Navigator Props

        [ForeignKey("Center")]
        public Guid CenterId { get; set; }
        public virtual Center Center { get; set; }

        [ForeignKey("Clinic")]
        public Guid ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

    }
}
