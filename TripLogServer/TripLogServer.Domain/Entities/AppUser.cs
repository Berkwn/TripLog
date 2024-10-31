using Microsoft.AspNetCore.Identity;

namespace TripLogServer.Domain.Entities;

public class AppUser : IdentityUser
{
    public bool IsAuthor { get; set; }
}
