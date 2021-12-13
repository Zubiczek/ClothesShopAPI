using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.PostDTO
{
    public class AddToBasketDTO
    {
        public int Cloth_Id { get; set; }
        public int Size_Id { get; set; }
    }
}
