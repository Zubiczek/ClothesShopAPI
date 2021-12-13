using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Queries.CommentQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentQueries _commentQueries;
        public CommentController(ICommentQueries commentQueries)
        {
            _commentQueries = commentQueries;
        }
        [Route("cloth/{id}/comments")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetComments(int id)
        {
            try
            {
                var comments = await _commentQueries.GetComments(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [Route("cloth/{id}/addcomment")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNewComment([FromBody]AddCommentDTO newcomment)
        {
            try
            {
                await _commentQueries.AddComment(newcomment);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
