using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Center
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Speciality { get; set; }//multi
        //public string Phone { get; set; } //multi
        public string Address { get; set; }

        //Navigator props
        public virtual List<CenterPhone> Center_Phones { get; set; }
        public virtual List<CenterSpeciality> Center_Specialities { get; set; }
        public virtual List<CenterInsurance> Center_Insurances { get; set; }
        public virtual List<Center_doctor> Doctor_Centers { get; set; }
        public virtual List<WeekDays> Center_WeekDays { get; set; }

    }
}
