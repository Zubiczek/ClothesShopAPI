using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.TokenServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ClothesShopAPI.Services.LoginService
{
    public class ClassicLoginService : ILoginService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClassicLoginService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, 
            ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<TokenOutput> SignIn(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) throw new MyException(400, "Niepoprawny login lub hasło");
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!signInResult.Succeeded) throw new MyException(400, "Niepoprawny login lub hasło");
            if (!user.EmailConfirmed) throw new MyException(400, "Wymagane potwierdzenie email");
            var accessToken = _tokenService.CreateAccessToken(user);
            TokenOutput token = new TokenOutput();
            token.AccessToken = accessToken.Item1;
            token.Expires = accessToken.Item2;
            token.RefreshToken = await _tokenService.CreateRefreshToken(user.Id);
            token.Id = user.Id;
            token.Email = user.Email;
            token.UserName = user.UserName;
            return token;
        }
        public async Task SignOut(string token)
        {
            int result = await _tokenService.RemoveRefreshToken(token);
            if (result != 0) throw new MyException(500);
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
