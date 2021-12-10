using ClothesShopAPI.Services.EmailService;
using ClothesShopAPI.Services.LoginService;
using ClothesShopAPI.Services.RegisterService;
using ClothesShopAPI.Services.TokenServices;
using ClothesShopAPI.Services.ValidationService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.ServiceExtensions
{
    public static class ServiceConfigure
    {
        public static void AddScopedServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, VerificationEmailService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, ClassicLoginService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IValidationService, ExistingUserValidationService>();
        }
    }
}
