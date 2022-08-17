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


        Task AddPhone(CenterPhone centerPhone);
        Task AddSpeciality(CenterSpeciality centerSpeciality);
        Task AddInsuranceCompany(CenterInsurance centerInsurance);
        Task AddDoctor(Center_doctor center_Doctor);
        Task AddWeekDay(WeekDays weekDays);

        Task<IQueryable<Center>> getCenters();

        Task<Center> getCenter(Guid id);





    }
}
