using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;
using TripLogServer.Domain.Repositories;
using TripLogServer.Infrastructure.Context;

namespace TripLogServer.Infrastructure.Abstractions
{
    internal sealed class TripRepository : Repository<TripEntity, ApplicationDbContext>, ITripRepository
    {
            private readonly DbSet<TripEntity> _context;
        public TripRepository(ApplicationDbContext context) : base(context)
        {
            _context = context.Set<TripEntity>();
        }

        public TripEntity FirstOrDefault(Expression<Func<TripEntity, bool>> expression)
        {
            return _context.Include(x=>x.Tags).Include(x=>x.TripContents).FirstOrDefault(expression);
        }

        public  IQueryable<TripEntity> GetAllTripWithContents() 
        {
            var response=  _context.Include(x=>x.Tags).Include(x=>x.TripContents).Select(x=>
            new TripEntity
            {
                Id=x.Id,
                Title=x.Title,
                 Description=x.Description,
                 ImageUrl = x.ImageUrl,
                 CreatedDate=x.CreatedDate,
                 AppUserId=x.AppUserId,
                Tags = x.Tags.Select(x=> new Tag
                {
                     Id= x.Id,
                     Name=x.Name,
                    
                }).ToList(),
                 TripContents = x.TripContents.Select(x=> new TripContent
                 {
                     Id = x.Id,
                     Title  = x.Title,
                     Description = x.Description,
                     ImageUrl=x.ImageUrl,
                     
                 }).ToList(),

                 AppUser=x.AppUser,
                 Commands=x.Commands,

            }
             
            ).AsQueryable();
            return response;

        }
    }
}
