using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {

        private readonly HospitalContext _context;

        public PatientRepository(HospitalContext context):base(context)
        {
            this._context = context;
        }


    }
}
