using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using ClothesShopAPI.Services.LoginService;
using ClothesShopAPI.Services.RegisterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        private readonly ICurrentLoggedInUser _currentLoggedInUser;
        public UserController(IRegisterService registerService, ILoginService loginService, 
            ICurrentLoggedInUser currentLoggedInUser)
        {
            _registerService = registerService;
            _loginService = loginService;
            _currentLoggedInUser = currentLoggedInUser;
        }
        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterNewUser([FromBody]CreateUserDTO newuser)
        {
            try
            {
                await _registerService.CreateNewUser(newuser);
                return Ok();
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode, ex.StatusMessage);
            }
        }
        [Route("confirm/email")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                await _registerService.ConfirmEmail(userId, token);
                return Ok();
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode, ex.StatusMessage);
            }
        }
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody]LoginDTO loginmodel)
        {
            try
            {
                var token = await _loginService.SignIn(loginmodel);
                return Ok(token);
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode, ex.StatusMessage);
            }
        }
        [Route("logout")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(string refreshtoken)
        {
            try
            {
                await _loginService.SignOut(refreshtoken);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
