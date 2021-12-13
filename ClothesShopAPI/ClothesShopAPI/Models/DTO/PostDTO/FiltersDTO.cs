using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.PostDTO
{
    public class FiltersDTO
    {
        public decimal MaxPrice { get; set; }
        public bool Discount { get; set; }
        public int Category_Id { get; set; }
        public int Mark_Id { get; set; }
        public int Gender_Id { get; set; }
    }
}
