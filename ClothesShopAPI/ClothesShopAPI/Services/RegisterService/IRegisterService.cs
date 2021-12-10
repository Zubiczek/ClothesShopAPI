using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.RegisterService
{
    public interface IRegisterService
    {
        Task CreateNewUser(CreateUserDTO newuser);
        Task ConfirmEmail(string userid, string token);
    }
}
