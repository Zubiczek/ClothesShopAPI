using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.PostDTO
{
    public class AddCommentDTO
    {
        public string Comment { get; set; }
        public int Cloth_Id { get; set; }
    }
}
