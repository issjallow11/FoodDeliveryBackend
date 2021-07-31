using FoodDeliveryBackend.Data.ViewModels;
using FoodDeliveryBackend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Data.Services
{
    public class AuthService : IAuthenticateService
    {

        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;


        public AuthService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public string Authenticate(AuthUser user)
        {
            User appUser = _context.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if(appUser == null)
            {
                return null;
            }
            return GenerateToken(appUser);
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(_configuration["JwtConfig:Issuer"], _configuration["JwtConfig:Audience"], claims, expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtConfig:ExpiryPeriod"])),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public void Register(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }



    }
}
