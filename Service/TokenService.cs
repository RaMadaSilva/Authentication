using System.Security.Permissions;
using System.Text;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutenticatiosAutorization.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AutenticatiosAutorization.Service
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Setting.secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandeler.CreateToken(tokenDescriptor);

            return tokenHandeler.WriteToken(token);
        }
    }
}