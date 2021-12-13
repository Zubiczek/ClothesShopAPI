using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Queries.UserQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IPasswordQueries _passwordQueries;
        private readonly IAdressQueries _addressQueries;
        public ProfileController(IPasswordQueries passwordQueries, IAdressQueries adressQueries)
        {
            _passwordQueries = passwordQueries;
            _addressQueries = adressQueries;
        }
        [Route("forgotpassword/sendemail")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordSendEmail([FromBody]string email)
        {
            try
            {
                await _passwordQueries.ResetPasswordSendEmail(email);
                return Ok();
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode, ex.StatusMessage);
            }
        }
        [Route("forgotpassword/verification")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ResetPasswordVerification(string userid, string token)
        {
            try
            {
                var result = await _passwordQueries.ResetPasswordVerification(userid, token);
                return Ok(new UserResetPasswordDTO
                {
                    User_Id = result.Item1,
                    Token = result.Item2
                });
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
        [Route("password/reset")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDTO resetmodel)
        {
            try
            {
                await _passwordQueries.ResetPassword(resetmodel);
                return Ok();
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
        [Route("password/change")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ChangePasswordDTO changemodel)
        {
            try
            {
                await _passwordQueries.ChangePassword(changemodel);
                return Ok();
            }
            catch (MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
        [Route("address/modify")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SetNewAddress([FromBody] NewAddressDTO address)
        {
            try
            {
                await _addressQueries.SetNewAddress(address);
                return Ok();
            }
            catch (MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
    }
}
