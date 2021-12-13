using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.CommentQueries
{
    public interface ICommentQueries
    {
        Task<List<CommentDTO>> GetComments(int id);
        Task AddComment(AddCommentDTO comment);
    }
}
