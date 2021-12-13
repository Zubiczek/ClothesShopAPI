using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.CurrentLoggedInUser
{
    public interface ICurrentLoggedInUser
    {
        string GetUserId();
        ClaimsPrincipal GetUserClaims();
    }
}
