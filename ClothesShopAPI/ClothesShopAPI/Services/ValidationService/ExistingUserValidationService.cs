using ClothesShopAPI.Database;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.ValidationService
{
    public class ExistingUserValidationService : IValidationService
    {
        private readonly Context _context;
        public ExistingUserValidationService(Context context)
        {
            _context = context;
        }
        public int Validate(dynamic model)
        {
            CreateUserDTO newuser = model as CreateUserDTO;
            var user = _context.User.Where(x => x.Email == newuser.Email || x.UserName == newuser.UserName).FirstOrDefault();
            if(user == null) return 0;
            else
            {
                if (user.Email == newuser.Email) return 1;
                else return 2;
            }
        }
    }
}
