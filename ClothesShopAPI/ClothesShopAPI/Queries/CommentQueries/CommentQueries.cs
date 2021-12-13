using AutoMapper;
using ClothesShopAPI.Database;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Services.CurrentLoggedInUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.CommentQueries
{
    public class CommentQueries : ICommentQueries
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly ICurrentLoggedInUser _currentUser;
        public CommentQueries(Context context, IMapper mapper, ICurrentLoggedInUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        public async Task<List<CommentDTO>> GetComments(int id)
        {
            var comments = await _context.ClothComments.Include(x => x.User).Where(x => x.Cloth_Id == id).Select(x =>
                new CommentDTO
                {
                    Comment = x.Comment,
                    CreatedOn = x.CreatedOn,
                    UserName = x.User.UserName
                }
            ).AsSingleQuery().AsNoTracking().ToListAsync();
            return comments;
        }
        public async Task AddComment(AddCommentDTO comment)
        {
            string userid = _currentUser.GetUserId();
            ClothCommentsEntity newcomment = new ClothCommentsEntity();
            newcomment = _mapper.Map<ClothCommentsEntity>(comment);
            newcomment.User_Id = userid;
            _context.Add(newcomment);
            await _context.SaveChangesAsync();
        }
    }
}
