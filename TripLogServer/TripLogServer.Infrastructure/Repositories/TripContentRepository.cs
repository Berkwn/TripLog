﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TripLogServer.Infrastructure.Context;

namespace TripLogServer.Infrastructure.Abstractions
{
    internal sealed class TripContentRepository : Repository<TripContent,ApplicationDbContext>
    {
        public TripContentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}