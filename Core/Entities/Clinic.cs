using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Clinic
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        //Navigator Properties
        public Guid DocId { get; set; }
        public virtual Doctor Doctor { get; set; }


    }
}
