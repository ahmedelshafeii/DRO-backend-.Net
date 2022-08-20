using Core.Entities;
using Core.Entities.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientRepository:IBaseRepository<User>
    {
        Task AddReview<T>(T review) where T : Review;

    }
}
