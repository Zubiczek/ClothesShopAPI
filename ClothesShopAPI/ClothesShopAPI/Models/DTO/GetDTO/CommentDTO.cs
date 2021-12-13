using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.GetDTO
{
    public class CommentDTO
    {
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
    }
}
