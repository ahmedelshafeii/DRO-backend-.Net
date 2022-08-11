using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Center
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }



        //Navigator props


        //[ForeignKey("Doctor")]
        public Guid DocAdminId { get; set; }

        //public Doctor Doctor { get; set; }

        public virtual List<CenterPhone> Center_Phones { get; set; }
        public virtual List<CenterSpeciality> Center_Specialities { get; set; }
        public virtual List<CenterInsurance> Center_Insurances { get; set; }
        public virtual List<Center_doctor> Center_Doctors { get; set; }
        public virtual List<WeekDays> Center_WeekDays { get; set; }

    }
}
