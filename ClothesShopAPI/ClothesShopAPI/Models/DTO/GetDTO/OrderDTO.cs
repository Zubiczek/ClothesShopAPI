using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.GetDTO
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsItPaid { get; set; }
        public bool IsItSend { get; set; }
        public bool IsItDelivered { get; set; }
        public List<OrderClothesDTO> Clothes { get; set; }
    }
}
