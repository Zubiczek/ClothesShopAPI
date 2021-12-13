using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.UserQueries
{
    public interface IPasswordQueries
    {
        Task ChangePassword(ChangePasswordDTO passwd);
        Task ResetPasswordSendEmail(string email);
        Task<(string, string)> ResetPasswordVerification(string userid, string token);
        Task ResetPassword(ResetPasswordDTO resetmodel);
    }
}
