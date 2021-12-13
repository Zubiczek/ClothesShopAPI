using AutoMapper;
using ClothesShopAPI.Database;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using ClothesShopAPI.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.UserQueries
{
    public class UserQueries : IAdressQueries
    {
        private readonly Context _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ICurrentLoggedInUser _currentLoggedInUser;
        private readonly IMapper _mapper;
        public UserQueries(Context context, UserManager<UserEntity> userManager, ICurrentLoggedInUser currentLoggedInUser,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _currentLoggedInUser = currentLoggedInUser;
            _mapper = mapper;
        }

        public async Task SetNewAddress(NewAddressDTO address)
        {
            var user = await _userManager.GetUserAsync(_currentLoggedInUser.GetUserClaims());
            if (user == null) throw new MyException(401);
            _mapper.Map<NewAddressDTO, UserEntity>(address, user);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
