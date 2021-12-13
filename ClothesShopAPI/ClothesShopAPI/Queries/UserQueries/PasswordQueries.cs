using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using ClothesShopAPI.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.UserQueries
{
    public class PasswordQueries : IPasswordQueries
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly ICurrentLoggedInUser _currentLoggedInUser;
        private readonly IEmailService _emailService;
        public PasswordQueries(UserManager<UserEntity> userManager, ICurrentLoggedInUser currentLoggedInUser,
            IEnumerable<IEmailService> emailServices)
        {
            _userManager = userManager;
            _currentLoggedInUser = currentLoggedInUser;
            _emailService = emailServices.First(x => x.GetType() == typeof(ResetPasswordEmailService));
        }
        public async Task ChangePassword(ChangePasswordDTO passwd)
        {
            var user = await _userManager.GetUserAsync(_currentLoggedInUser.GetUserClaims());
            if (user == null) throw new MyException(401);
            var result = await _userManager.ChangePasswordAsync(user, passwd.OldPassword, passwd.NewPassword);
            if (!result.Succeeded) throw new MyException(400, "Nieprawidłowe hasło");
        }
        public async Task ResetPasswordSendEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new MyException(404, "Nieprawidłowy email");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _emailService.SendEmail(user, token);
        }
        public async Task<(string, string)> ResetPasswordVerification(string userid, string token)
        {
            if (userid == null || token == null) throw new MyException(400);
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null) throw new MyException(500);
            return (userid, token);
        }
        public async Task ResetPassword(ResetPasswordDTO resetmodel)
        {
            var user = await _userManager.FindByIdAsync(resetmodel.User_Id);
            if (user == null) throw new MyException(500);
            var result = await _userManager.ResetPasswordAsync(user, resetmodel.Token, resetmodel.NewPassword);
            if (!result.Succeeded) throw new MyException(500);
        }
    }
}
