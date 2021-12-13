using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.SearchQueries
{
    public interface ISearchQueries
    {
        Task<List<ClothsDTO>> GetAllClothes(int pagenumber);
        Task<List<ClothsDTO>> GetSearchedClothes(string name);
        Task<List<ClothsDTO>> GetSearchedByFilters(List<ClothsDTO> clothes, FiltersDTO filters);
    }
}
