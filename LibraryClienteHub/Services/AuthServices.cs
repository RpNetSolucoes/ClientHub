using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryClienteHub.Models
{
    public partial class AuthServices : IAuthServices
    {
        private readonly DbClientHubContext _db;
        private readonly IConfiguration _config;

        public AuthServices(DbClientHubContext db, IConfiguration configuration)
        {
            _db = db;
            _config = configuration;
        }

        public async Task<bool> AuthenticateAsync(string userName, string password)
        {
            var cliente = await _db.Auth.Where(x => x.Client == userName && x.Password == password).FirstOrDefaultAsync();
            if(cliente == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<string> GenerateToken(int id, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim("id", id.ToString()),
            new Claim("userName", userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        public async Task<AuthToken> UserExists(string userName)
        {
            var result = await _db.Auth.FirstOrDefaultAsync(x => x.Client == userName);
            return result;
        }
    }
}
