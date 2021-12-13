using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.UserQueries
{
    public interface IAdressQueries
    {
        Task SetNewAddress(NewAddressDTO address);
    }
}
