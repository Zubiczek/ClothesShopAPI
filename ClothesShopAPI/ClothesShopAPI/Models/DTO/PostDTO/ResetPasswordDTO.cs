using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.PostDTO
{
    public class ResetPasswordDTO
    {
        public string User_Id { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
