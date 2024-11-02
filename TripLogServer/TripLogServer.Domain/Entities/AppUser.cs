using Microsoft.AspNetCore.Identity;

namespace TripLogServer.Domain.Entities;

public class AppUser : IdentityUser
{
    public bool IsAuthor { get; set; }
    public ICollection<Command>? Commands { get; set; }

    public ICollection<TripEntity>? TripEntities { get; set; }


}
