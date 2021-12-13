using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.GetDTO
{
    public class ClothDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public bool IsItInStock { get; set; }
        public string Description { get; set; }
        public uint Discount { get; set; }
        public string Gender_Name { get; set; }
        public string Mark_Name { get; set; }
        public string Category_Name { get; set; }
        public OpinionDTO Opinion { get; set; }
    }
}
