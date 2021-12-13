using AutoMapper;
using ClothesShopAPI.Database;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.BasketQueries
{
    public class UserBasketQueries : IBasketQueries
    {
        private readonly Context _context;
        private readonly ICurrentLoggedInUser _currentUser;
        private readonly IMapper _mapper;
        public UserBasketQueries(Context context, ICurrentLoggedInUser currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }
        public async Task AddToBasket(AddToBasketDTO model)
        {
            if (model == null) throw new MyException(500);
            UserBasketEntity basket = new UserBasketEntity();
            _mapper.Map<AddToBasketDTO, UserBasketEntity>(model, basket);
            basket.User_Id = _currentUser.GetUserId();
            _context.Add(basket);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ClothsDTO>> GetProductsFromBasket()
        {
            string userid = _currentUser.GetUserId();
            var clothes = await _context.UserBasket.Include(x => x.Cloth).Where(x => x.User_Id == userid).Select(x =>
                new ClothsDTO
                {
                    Id = x.Cloth.Id,
                    Fullname = x.Cloth.Fullname,
                    Price = x.Cloth.Price,
                    Img = x.Cloth.Img,
                    Discount = x.Cloth.Discount,
                    Mark_Name = x.Cloth.Mark.MarkName,
                    Mark_Id = x.Cloth.Mark_Id,
                    Category_Id = x.Cloth.Category_Id,
                    Gender_Id = x.Cloth.Gender_Id
                }
            ).AsSingleQuery().AsNoTracking().ToListAsync();
            return clothes;
        }
        public async Task DeleteFromBasket(int id)
        {
            string userid = _currentUser.GetUserId();
            var clothfrombasket = await _context.UserBasket.Where(x => x.Cloth_Id == id && x.User_Id == userid)
                .FirstOrDefaultAsync();
            if (clothfrombasket == null) throw new MyException(400);
            _context.UserBasket.Remove(clothfrombasket);
            await _context.SaveChangesAsync();
        }
    }
}
