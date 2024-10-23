using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;

namespace TripLogServer.Infrastructure.Context
{
    public sealed class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }
       DbSet<TripEntity> Trips { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TripContent> Contents { get; set; }    
    }

  
}


