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

        public void AddDoctor()
        {
            throw new NotImplementedException();
        }

        public void AddInsurance()
        {
            throw new NotImplementedException();
        }

        public void AddPhone(CenterPhone centerPhone)
        {
            _context.Add(centerPhone);
            _context.SaveChanges();
        }

        public async void AddSpeciality(CenterSpeciality centerSpeciality)
        {
            await _context.AddAsync(centerSpeciality);
            _context.SaveChanges();
        }

        public IEnumerable<Center> getCenters()
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
