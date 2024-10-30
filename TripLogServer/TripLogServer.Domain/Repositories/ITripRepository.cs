using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Abstractions;
using TripLogServer.Domain.Entities;

namespace TripLogServer.Domain.Repositories
{
    public interface ITripRepository:IRepository<TripEntity>
    {
         IQueryable<TripEntity> GetAllTripWithContents();

         TripEntity FirstOrDefault(Expression<Func<TripEntity, bool>> expression);
    }
    
    
}
