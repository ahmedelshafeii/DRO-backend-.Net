using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CenterSpeciality
    {
        [ForeignKey("Center")]
        public Guid CenterId { get; set; }
        public string Speciality { get; set; }

        public virtual Center Center { get; set; }
    }
}
