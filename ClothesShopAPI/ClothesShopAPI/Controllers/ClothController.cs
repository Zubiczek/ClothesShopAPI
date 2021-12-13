using ClothesShopAPI.Queries.ClothQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ClothController : ControllerBase
    {
        private readonly IGetClothQueries _getClothQueries;
        public ClothController(IGetClothQueries getClothQueries)
        {
            _getClothQueries = getClothQueries;
        }
        [Route("clothes/discount")]
        [HttpGet]
        public async Task<IActionResult> GetClothesOnDiscount()
        {
            var clothes = await _getClothQueries.GetClothsWithDiscount();
            return Ok(clothes);
        }
        [Route("clothes/gender/{gender}")]
        [HttpGet]
        public async Task<IActionResult> GetClothesByGender(string gender)
        {
            var clothes = await _getClothQueries.GetClothByGender(gender);
            return Ok(clothes);
        }
        [Route("clothes/category/{category}")]
        [HttpGet]
        public async Task<IActionResult> GetClothesByCategory(string category)
        {
            var clothes = await _getClothQueries.GetClothByCategory(category);
            return Ok(clothes);
        }
        [Route("clothes/mark/{mark}")]
        [HttpGet]
        public async Task<IActionResult> GetClothesByMark(string mark)
        {
            var clothes = await _getClothQueries.GetClothByMark(mark);
            return Ok(clothes);
        }
        [Route("cloth/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClothById(int id)
        {
            try
            {
                var cloth = await _getClothQueries.GetClothById(id);
                return Ok(cloth);
            }
            catch
            {
                return NotFound();
            } 
        }
    }
}
