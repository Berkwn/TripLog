﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLogServer.Domain.Entities
{
   public sealed class TripEntity
    {
        public TripEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Tag>? Tags { get; set; }
        public ICollection<TripContent>? TripContents { get; set; }
    }
}
