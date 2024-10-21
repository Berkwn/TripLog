using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Abstractions;
using TripLogServer.Domain.Entities;

namespace TripLogServer.Domain.Repositories
{
    public interface ITripContentRepository:IRepository<TripContent>
    {
    }
}
