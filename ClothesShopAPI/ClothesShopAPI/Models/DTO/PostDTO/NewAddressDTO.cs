using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.PostDTO
{
    public class NewAddressDTO
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
