using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLogServer.Domain.Entities
{
    public sealed class Command
    {
        public Command() 
        {
           Id= Guid.NewGuid();
             
        }
        public Guid Id { get; set; }
        public AppUser? AppUser { get; set; }
        public string AppUserId { get; set; } = default!;
        public TripEntity? TripEntity { get; set; }
        public Guid TripEntityId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = default!;







    }
}
