using Core.Entities;
using Core.Entities.Review;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<User>, IPatientRepository
    {

        private readonly HospitalContext _context;

        public PatientRepository(HospitalContext context):base(context)
        {
            this._context = context;
        }

       
        public async Task AddReview<T>(T review) where T : Review
        {
            await _context.Set<T>().AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}
