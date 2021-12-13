using ClothesShopAPI.Models.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.OrderQueries
{
    public interface ISeeOrderQueries
    {
        Task<OrderDTO> SeeMyOrder(string id);
    }
}
