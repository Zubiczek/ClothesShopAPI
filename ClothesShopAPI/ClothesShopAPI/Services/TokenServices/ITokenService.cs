using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.TokenServices
{
    public interface ITokenService
    {
        (string, DateTime) CreateAccessToken(UserEntity user);
        Task<string> CreateRefreshToken(string userId);
        Task<TokenOutput> RefreshToken(string token);
        Task<int> RemoveRefreshToken(string token);
        bool IsTokenValid(string token);
    }
}
