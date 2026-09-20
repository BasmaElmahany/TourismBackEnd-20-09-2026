using Tourism.Application.Interfaces;
using DTourism.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Tourism.Infrastructure.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
    {
        // Standard JWT Claims
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty),

        // ASP.NET Identity Claims
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.FullName ?? string.Empty),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),

        // Custom Claims
        new Claim("UserName", user.UserName ?? string.Empty),
        new Claim("FullName", user.FullName ?? string.Empty),
        new Claim("Email", user.Email ?? string.Empty)
    };

            var jwtKey = _configuration["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(jwtKey))
                throw new Exception("JWT Key is missing from configuration.");

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey));

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials);

            return Task.FromResult(
                new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
