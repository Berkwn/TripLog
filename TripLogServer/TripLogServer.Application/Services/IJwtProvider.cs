using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Domain.Entities;

namespace TripLogServer.Application.Services
{
    public interface IJwtProvider
    {
        Task<string> CreateToken(AppUser user);
    }
}
