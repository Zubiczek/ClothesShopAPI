using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.OpinionQueries
{
    public interface IOpinionQueries
    {
        Task AddOpinion(AddOpinionDTO opinion, string userid);
    }
}
