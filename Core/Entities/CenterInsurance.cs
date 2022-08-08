
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CenterInsurance
    {
        [ForeignKey("Center")]
        public Guid CenterId { get; set; }
        public string InsuranceCompany { get; set; }

        public virtual Center Center { get; set; }


    }
}
