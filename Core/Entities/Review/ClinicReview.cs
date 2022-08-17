using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Review
{
    public class ClinicReview : Review
    {
       
        //Navigator Props
       
        [ForeignKey("Clinic")]
        public Guid ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
