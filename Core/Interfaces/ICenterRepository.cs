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
        public void AddInsuranceCompany(CenterInsurance centerInsurance);
        public void AddDoctor(Center_doctor center_Doctor);
        public void AddWeekDay(WeekDays weekDays);

        public IEnumerable<Center> getCenters();

        public Center getCenter(Guid id);





    }
}
