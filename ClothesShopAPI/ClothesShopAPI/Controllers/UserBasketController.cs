using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Queries.BasketQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class UserBasketController : ControllerBase
    {
        private readonly IBasketQueries _basketQueries;
        public UserBasketController(IEnumerable<IBasketQueries> basketQueries)
        {
            _basketQueries = basketQueries.First(x => x.GetType() == typeof(UserBasketQueries));
        }
        [Route("user/basket")]
        [HttpGet]
        public async Task<IActionResult> GetClothFromBasket()
        {
            try
            {
                var clothes = await _basketQueries.GetProductsFromBasket();
                return Ok(clothes);
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
        [Route("user/addtobasket")]
        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody]AddToBasketDTO model)
        {
            try
            {
                await _basketQueries.AddToBasket(model);
                return Ok();
            }
            catch (MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
        [Route("basket/delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            try
            {
                await _basketQueries.DeleteFromBasket(id);
                return Ok();
            }
            catch (MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
    }
}
