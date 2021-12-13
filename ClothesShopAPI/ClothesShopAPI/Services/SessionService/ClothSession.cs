using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.SessionService
{
    public class ClothSession : IClothSessionService
    {
        private HttpContext _httpContext;
        public ClothSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public List<ClothsDTO> Get()
        {
            ISessionFeature sessionFeature = _httpContext.Features.Get<ISessionFeature>();
            if (sessionFeature == null) throw new MyException();
            if (sessionFeature.Session.GetString("CurrentClothes") == null) return null;
            var clothes = JsonConvert.DeserializeObject<List<ClothsDTO>>(sessionFeature.Session.GetString("CurrentClothes"));
            return clothes;
        }

        public void Save(List<ClothsDTO> clothes)
        {
            ISessionFeature sessionFeature = _httpContext.Features.Get<ISessionFeature>();
            if (sessionFeature == null) throw new MyException();
            var serializeclothes = JsonConvert.SerializeObject(clothes);
            sessionFeature.Session.SetString("CurrentClothes", serializeclothes);
        }
    }
}
