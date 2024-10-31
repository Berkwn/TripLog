using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TripLogServer.Application.Services;
using TripLogServer.Domain.Entities;

namespace TripLogServer.Infrastructure.Services
{
    public class JwtProvider(IConfiguration configuration) : IJwtProvider
    {
        public async Task<string> CreateToken(AppUser user)
        {
            List<Claim> claims = new()
           {
              new Claim(ClaimTypes.NameIdentifier,user.Id),
              new Claim(ClaimTypes.Role,user.UserName),
              new Claim(ClaimTypes.Email,user.Email),
              new Claim("IsAuthor",user.IsAuthor.ToString(),ClaimValueTypes.Boolean)
           };

            DateTime expireDate= DateTime.UtcNow.AddDays(1);

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value ?? ""));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);


            JwtSecurityToken securityToken = new(
                issuer: configuration.GetSection("Jwt:Issuer").Value,
                audience: configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                notBefore: DateTime.Now,
                expires:expireDate,
                signingCredentials:signingCredentials

                );

            JwtSecurityTokenHandler handler = new();
            string token = handler.WriteToken(securityToken);

            return token;
        }
    }
}
