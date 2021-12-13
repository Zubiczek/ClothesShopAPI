using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.GetDTO
{
    public class UserResetPasswordDTO
    {
        public string User_Id { get; set; }
        public string Token { get; set; }
    }
}
