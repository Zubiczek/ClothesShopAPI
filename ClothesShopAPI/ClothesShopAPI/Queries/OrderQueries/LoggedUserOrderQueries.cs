using ClothesShopAPI.Database;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.OrderQueries
{
    public class LoggedUserOrderQueries : ISeeOrderQueries, IMakeOrderQueries
    {
        private readonly Context _context;
        private readonly ICurrentLoggedInUser _currentUser;
        public LoggedUserOrderQueries(Context context, ICurrentLoggedInUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task MakeOrder()
        {
            string userid = _currentUser.GetUserId();
            var clothesids = await _context.UserBasket.Where(x => x.User_Id == userid).Select(x => x.Cloth_Id).ToListAsync();
            if (clothesids == null) throw new MyException(400);
            if (clothesids.Count > 3) throw new MyException(400);
            using(var transaction = _context.Database.BeginTransaction())
            {
                OrdersEntity neworder = new OrdersEntity();
                neworder.Id = Guid.NewGuid().ToString();
                neworder.IsItPaid = false;
                neworder.IsItSend = false;
                neworder.IsItDelivered = false;
                neworder.User_Id = userid;
                _context.Add(neworder);
                await _context.SaveChangesAsync();
                foreach(var i in clothesids)
                {
                    OrderClothesEntity orderclothes = new OrderClothesEntity();
                    orderclothes.Order_Id = neworder.Id;
                    orderclothes.Cloth_Id = i;
                    _context.Add(orderclothes);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<OrderDTO> SeeMyOrder(string id)
        {
            var order = await _context.Orders.Where(x => x.Id == id).
                Select(x =>
                    new OrderDTO
                    {
                        Id = x.Id,
                        CreatedOn = x.CreatedOn,
                        IsItPaid = x.IsItPaid,
                        IsItSend = x.IsItSend,
                        IsItDelivered = x.IsItDelivered
                    }
                ).AsNoTracking().FirstOrDefaultAsync();
            if (order == null) throw new MyException(401);
            var clothes = await _context.OrderClothes.Include(x => x.Cloth).Where(x => x.Order_Id == order.Id).Select(x =>
                new OrderClothesDTO
                {
                    Fullname = x.Cloth.Fullname,
                    Price = x.Cloth.Price
                }
            ).AsSingleQuery().AsNoTracking().ToListAsync();
            if(clothes == null) throw new MyException(500);
            order.Clothes = clothes;
            return order;
        }
    }
}
