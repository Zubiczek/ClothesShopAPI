using ClothesShopAPI.Database;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.Others;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.TokenServices
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        public JwtTokenService(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            _context = context;
        }
        public (string, DateTime) CreateAccessToken(UserEntity user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var expires = DateTime.UtcNow.AddMinutes(15);

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: credentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return (jwtSecurityTokenHandler.WriteToken(jwtSecurityToken), expires);
        }

        public async Task<string> CreateRefreshToken(string userId)
        {
            var createdOn = DateTime.UtcNow;
            var expiresOn = createdOn.AddMonths(1);

            var refreshToken = new RefreshTokenEntity
            {
                User_Id = userId,
                CreatedOn = createdOn,
                ExpiresOn = expiresOn,
                Token = Guid.NewGuid().ToString()
            };

            _context.RefreshToken.Add(refreshToken);
            await _context.SaveChangesAsync();

            return refreshToken.Token;
        }

        public async Task<TokenOutput> RefreshToken(string token)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var refreshToken = await _context.RefreshToken
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Token == token);

                if (refreshToken == null)
                {
                    throw new Exception("Bad request");
                }

                if (!refreshToken.IsActive())
                {
                    throw new Exception("Unauthorized");
                }

                var user = refreshToken.User;

                _context.RefreshToken.Remove(refreshToken);
                await _context.SaveChangesAsync();
                transaction.Commit();

                var accessToken = CreateAccessToken(user);

                return new TokenOutput()
                {
                    AccessToken = accessToken.Item1,
                    Expires = accessToken.Item2,
                    RefreshToken = await CreateRefreshToken(user.Id),
                    Id = user.Id,
                    Email = user.UserName,
                    UserName = user.UserName
                };
            }
        }

        public async Task<int> RemoveRefreshToken(string token)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var refreshToken = await _context.RefreshToken
                    .FirstOrDefaultAsync(x => x.Token == token);
                if (refreshToken == null)
                {
                    return 1;
                }
                _context.RefreshToken.Remove(refreshToken);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            return 0;
        }
        public bool IsTokenValid(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Issuer"],
                    IssuerSigningKey = key,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
