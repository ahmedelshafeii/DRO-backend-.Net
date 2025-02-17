﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }

        //Navigator Propirties
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        

        public virtual IEnumerable<Center_doctor> Doctor_Centers { get; set;}
        public virtual IEnumerable<Clinic> Clinics { get; set; }

        public virtual IEnumerable<Center> CentersManage { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }



    }
}
