using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Queries.OpinionQueries;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly IOpinionQueries _opinionQueries;
        private readonly ICurrentLoggedInUser _currentLoggedInUser;
        public OpinionController(IOpinionQueries opinionQueries, ICurrentLoggedInUser currentLoggedInUser)
        {
            _opinionQueries = opinionQueries;
            _currentLoggedInUser = currentLoggedInUser;
        }
        [Route("addopinion")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOpinion([FromBody] AddOpinionDTO opinion)
        {
            try
            {
                await _opinionQueries.AddOpinion(opinion, _currentLoggedInUser.GetUserId());
                return Ok();
            }
            catch(MyException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }
    }
}
