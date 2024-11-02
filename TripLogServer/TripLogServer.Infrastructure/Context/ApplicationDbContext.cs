using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        DbSet<Command> commands { get; set; }
        DbSet<AppUser> appUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AppUser>().HasKey(x => x.Id);


        }
    }
        

   
  
}


