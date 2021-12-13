using ClothesShopAPI.Models.Others;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.CurrentLoggedInUser
{
    public class CurrentLoggedInUserService : ICurrentLoggedInUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentLoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserId()
        {
            var userid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userid == null) throw new MyException(401);
            return userid;
        }
        public ClaimsPrincipal GetUserClaims()
        {
            return _httpContextAccessor.HttpContext.User;
        }
    }
}
