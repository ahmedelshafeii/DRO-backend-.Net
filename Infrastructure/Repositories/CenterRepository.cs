using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CenterRepository : BaseRepository<Center>, ICenterRepository
    {
        HospitalContext _context;
        public CenterRepository(HospitalContext context) : base(context)
        {
            this._context = context;
        }

        public async Task AddDoctor(Center_doctor center_Doctor)
        {
            await _context.Center_Doctors.AddAsync(center_Doctor);
            _context.SaveChanges();
        }

        public async Task AddPhone(CenterPhone centerPhone)
        {
            await _context.AddAsync(centerPhone);
            _context.SaveChanges();
        }

        public async Task AddSpeciality(CenterSpeciality centerSpeciality)
        {
            await _context.AddAsync(centerSpeciality);
            _context.SaveChanges();
        }

        public async Task AddInsuranceCompany(CenterInsurance centerInsurance)
        {
            await _context.AddAsync(centerInsurance);
            _context.SaveChanges();
        }

        public async Task<Center> getCenter(Guid id)
        {
            Center center = _context.Centers.Include(i => i.Center_Phones)
                .Include(i => i.Center_Insurances)
                .Include(i => i.Center_Doctors)
                .Include(i => i.Center_Specialities).FirstOrDefault(i => i.Id == id) ?? null!;
            return center;
        }

        public async Task AddWeekDay(WeekDays weekDays)
        {
            await _context.AddAsync(weekDays);
            _context.SaveChanges();
        }

        public async Task<IQueryable<Center>> getCenters()
        {
            return _context.Centers.Include(i => i.Center_Phones)
                .Include(i => i.Center_Insurances)
                .Include(i => i.Center_Doctors)
                .Include(i => i.Center_Specialities)
                //.Include(i=>i.Center_WeekDays)
                ;
        }
    }
}
