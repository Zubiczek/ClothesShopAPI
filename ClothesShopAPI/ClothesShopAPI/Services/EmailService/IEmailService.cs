using ClothesShopAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(UserEntity user, string token);
    }
}
