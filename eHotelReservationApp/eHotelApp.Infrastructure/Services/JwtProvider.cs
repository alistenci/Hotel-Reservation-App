using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace eHotelApp.Infrastructure.Services
{
    internal sealed class JwtProvider(IConfiguration configuration) : IJwtProvider
    {
        public async Task<string> CreateTokenAsync(AppUser user)
        {
            var roles = new List<string> { "User" };

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim("Username", user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Role, JsonSerializer.Serialize(roles)),
            };

            DateTime expires = DateTime.Now.AddMinutes(1);

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value ?? ""));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);


            JwtSecurityToken jwtSecurityToken = new(
                issuer: configuration.GetSection("Jwt:Issuer").Value,
                audience: configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
