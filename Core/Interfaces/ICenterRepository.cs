using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICenterRepository : IBaseRepository<Center>
    {


        public void AddPhone(CenterPhone centerPhone);
        public void AddSpeciality(CenterSpeciality centerSpeciality);
        public void AddInsurance();
        public void AddDoctor();

        public IEnumerable<Center> getCenters();

        public Center getCenter(Guid id);





    }
}
