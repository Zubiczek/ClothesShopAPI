using ClothesShopAPI.Models.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.SessionService
{
    public interface IClothSessionService
    {
        public void Save(List<ClothsDTO> clothes);
        public List<ClothsDTO> Get();
    }
}
