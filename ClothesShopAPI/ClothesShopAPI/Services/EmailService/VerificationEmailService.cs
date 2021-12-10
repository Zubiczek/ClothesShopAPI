using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Services.EmailService.EmailModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.EmailService
{
    public class VerificationEmailService : IEmailService
    {
        private readonly IMailService _mailService;
        private readonly IUrlHelper _urlHelper;
        private HttpRequest _request;
        public VerificationEmailService(IMailService mailService,
            IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor)
        {
            _mailService = mailService;
            _urlHelper = urlHelper;
            _request = httpContextAccessor.HttpContext.Request;
        }
        public async Task SendEmail(UserEntity user, string token)
        {
            var confirmationlink = _urlHelper.Action
                ("ConfirmEmail", "User", new { userId = user.Id, token = token }, _request.Scheme);
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = user.Email;
            mailRequest.Subject = "clothstoreAWS.com - Weryfikacja konta";
            string mailtext = "<div style = 'background-color: #696969; color: white; margin-left: auto; margin-right: auto; width: 100%;'>" +
            "<div style = 'padding-top: 30px; text-align: center;'>" +
                "Witaj, Twoje konto jest prawie gotowe!" +
            "</div>" +
            "<div style = 'padding-top: 30px; text-align: center;'>" +
                "Kliknij poniższy przycisk aby aktywować swoje konto" +
            "</div>" +
            "<div style = 'background-color: #228B22; padding: 10px; width: 100px; margin-left: 42%; margin-top: 30px;'>" +
                "<a href = '" + confirmationlink + "' style = 'text-decoration:none'>" +
                    "<div style = 'text-align: center; color: white;'>" +
                        "Weryfikuj" +
                    "</div>" +
                "</a>" +
            "</div>" +
            "<div style = 'background-color: black; text-align: center; margin-top: 20px; color: white;'>" +
                "clothstoreAWS.com &copy Wszelkie prawa zastrzeżone!" +
            "</div>" +
            "</div>";
            mailRequest.Body = mailtext;
            await _mailService.SendEmailAsync(mailRequest);
        }
    }
}
