using ClothesShopAPI.Models.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.ClothQueries
{
    public interface IGetClothQueries
    {
        Task<List<ClothsDTO>> GetAllClothes();
        Task<List<ClothsDTO>> GetClothsWithDiscount();
        Task<List<ClothsDTO>> GetClothByGender(string gender);
        Task<List<ClothsDTO>> GetClothByCategory(string category);
        Task<List<ClothsDTO>> GetClothByMark(string mark);
        Task<ClothDTO> GetClothById(int id);
    }
}
