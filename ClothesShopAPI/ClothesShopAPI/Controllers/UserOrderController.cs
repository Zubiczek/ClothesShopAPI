using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Queries.OrderQueries;
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
    public class UserOrderController : ControllerBase
    {
        private readonly IMakeOrderQueries _makeOrder;
        private readonly ISeeOrderQueries _seeOrder;
        public UserOrderController(IEnumerable<IMakeOrderQueries> makeOrders, ISeeOrderQueries seeOrder)
        {
            _makeOrder = makeOrders.First(x => x.GetType() == typeof(LoggedUserOrderQueries));
            _seeOrder = seeOrder;
        }
        [Route("user/order/{id}")]
        [HttpGet]
        public async Task<IActionResult> SeeOrder(string id)
        {
            try
            {
                var order = await _seeOrder.SeeMyOrder(id);
                return Ok(order);
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
        [Route("user/neworder")]
        [HttpPost]
        public async Task<IActionResult> MakeNewOrder()
        {
            try
            {
                await _makeOrder.MakeOrder();
                return Ok();
            }
            catch (MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
    }
}
