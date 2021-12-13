using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using ClothesShopAPI.Queries.SearchQueries;
using ClothesShopAPI.Services.SessionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly ISearchQueries _searchQueries;
        private readonly IClothSessionService _sessionService;
        public SearchController(ISearchQueries searchQueries, IClothSessionService sessionService)
        {
            _searchQueries = searchQueries;
            _sessionService = sessionService;
        }
        [Route("page/{pagenumber}")]
        [HttpGet]
        public async Task<IActionResult> GetClothesOnPage(int pagenumber)
        {
            try
            {
                var clothes = await _searchQueries.GetAllClothes(pagenumber);
                return Ok(clothes);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [Route("{name}")]
        [HttpGet]
        public async Task<IActionResult> GetClothesByName(string name)
        {
            try
            {
                var clothes = await _searchQueries.GetSearchedClothes(name);
                _sessionService.Save(clothes);
                return Ok(clothes);
            }
            catch(MyException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("filters")]
        [HttpPost]
        public async Task<IActionResult> GetClothesByFilters([FromBody]FiltersDTO filters)
        {
            try
            {
                var currentclothes = _sessionService.Get();
                var clothes = await _searchQueries.GetSearchedByFilters(currentclothes, filters);
                return Ok(clothes);
            }
            catch(MyException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
