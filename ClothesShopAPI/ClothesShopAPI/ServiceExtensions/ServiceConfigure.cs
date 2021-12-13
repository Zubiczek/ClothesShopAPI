using ClothesShopAPI.Queries.BasketQueries;
using ClothesShopAPI.Queries.ClothQueries;
using ClothesShopAPI.Queries.CommentQueries;
using ClothesShopAPI.Queries.OpinionQueries;
using ClothesShopAPI.Queries.SearchQueries;
using ClothesShopAPI.Queries.UserQueries;
using ClothesShopAPI.Queries.OrderQueries;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using ClothesShopAPI.Services.EmailService;
using ClothesShopAPI.Services.LoginService;
using ClothesShopAPI.Services.RegisterService;
using ClothesShopAPI.Services.SessionService;
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
            services.AddScoped<IGetClothQueries, ClothQueries>();
            services.AddScoped<ICommentQueries, CommentQueries>();
            services.AddScoped<IOpinionQueries, OpinionQueries>();
            services.AddScoped<IAdressQueries, UserQueries>();
            services.AddScoped<ICurrentLoggedInUser, CurrentLoggedInUserService>();
            services.AddScoped<ISearchQueries, SearchQueries>();
            services.AddScoped<IClothSessionService, ClothSession>();
            services.AddScoped<IEmailService, ResetPasswordEmailService>();
            services.AddScoped<IPasswordQueries, PasswordQueries>();
            services.AddScoped<IBasketQueries, UserBasketQueries>();
			services.AddScoped<>(IMakeOrderQueries, LoggedUserOrderQueries);
			services.AddScoped<>(ISeeOrderQueries, LoggedUserOrderQueries);
        }
    }
}
