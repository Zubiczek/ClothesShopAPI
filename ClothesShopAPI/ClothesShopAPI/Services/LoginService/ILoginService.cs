using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.LoginService
{
    public interface ILoginService
    {
        Task<TokenOutput> SignIn(LoginDTO model);
        Task SignOut(string token);
    }
}
