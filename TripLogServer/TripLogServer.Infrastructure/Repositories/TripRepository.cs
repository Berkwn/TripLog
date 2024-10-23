using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TripLogServer.Infrastructure.Context;

namespace TripLogServer.Infrastructure.Abstractions
{
    internal sealed class TripRepository : Repository<TripEntity, ApplicationDbContext>, ITripRepository
    {
        public TripRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
