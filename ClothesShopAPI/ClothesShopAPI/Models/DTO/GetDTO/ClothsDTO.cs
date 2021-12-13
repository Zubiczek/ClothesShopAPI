using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.GetDTO
{
    public class ClothsDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public uint Discount { get; set; }
        public string Mark_Name { get; set; }
        public int Category_Id { get; set; }
        public int Mark_Id { get; set; }
        public int Gender_Id { get; set; }
    }
}
