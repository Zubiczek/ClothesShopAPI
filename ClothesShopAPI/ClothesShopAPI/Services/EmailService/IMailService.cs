using ClothesShopAPI.Services.EmailService.EmailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MimeKit;

namespace ClothesShopAPI.Services.EmailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailrequest);
    }
}
