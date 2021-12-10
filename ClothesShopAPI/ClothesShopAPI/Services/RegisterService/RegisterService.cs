using AutoMapper;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.EmailService;
using ClothesShopAPI.Services.ValidationService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IEmailService _emailService;
        public RegisterService(IEnumerable<IValidationService> validationServices, IMapper mapper,
            UserManager<UserEntity> userManager, IEnumerable<IEmailService> emailServices)
        {
            _validationService = validationServices.First(x => x.GetType() == typeof(ExistingUserValidationService));
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailServices.First(x => x.GetType() == typeof(VerificationEmailService));
        }
        public async Task CreateNewUser(CreateUserDTO newuser)
        {
            int validationstatus = _validationService.Validate(newuser);
            if(validationstatus != 0)
            {
                throw new MyException(400 , validationstatus);
            }
            UserEntity user = _mapper.Map<UserEntity>(newuser);
            var passwordHash = new PasswordHasher<UserEntity>();
            var hashed = passwordHash.HashPassword(user, newuser.PasswordHash);
            user.PasswordHash = hashed;
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();
            var createuserresult = await _userManager.CreateAsync(user);
            if (!createuserresult.Succeeded) throw new MyException(500);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _emailService.SendEmail(user, token);
        }
        public async Task ConfirmEmail(string userid, string token)
        {
            if(userid == null || token == null) throw new MyException(401);
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null) throw new MyException(500);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded) throw new MyException(500);
        }
    }
}
