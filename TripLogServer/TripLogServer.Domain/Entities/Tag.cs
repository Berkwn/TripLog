using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLogServer.Domain.Entities
{
    public sealed class Tag
    {
        public Tag()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<TripEntity>? Trips { get; set; } 

    }
}
