using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.BasketQueries
{
    public interface IBasketQueries
    {
        Task<List<ClothsDTO>> GetProductsFromBasket();
        Task AddToBasket(AddToBasketDTO model);
        Task DeleteFromBasket(int id);
    }
}
