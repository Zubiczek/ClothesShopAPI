using ClothesShopAPI.Database;
using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.SearchQueries
{
    public class SearchQueries : ISearchQueries
    {
        private readonly Context _context;
        public SearchQueries(Context context)
        {
            _context = context;
        }
        public async Task<List<ClothsDTO>> GetAllClothes(int pagenumber)
        {
            var clothes = await _context.Cloth.Include(x => x.Mark).Select(x =>
                new ClothsDTO
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Price = x.Price,
                    Img = x.Img,
                    Discount = x.Discount,
                    Mark_Name = x.Mark.MarkName,
                    Mark_Id = x.Mark_Id,
                    Category_Id = x.Category_Id,
                    Gender_Id = x.Gender_Id
                }
            ).AsSplitQuery().AsNoTracking().Skip((pagenumber-1)*12).Take(12).ToListAsync();
            return clothes;
        }

        public async Task<List<ClothsDTO>> GetSearchedByFilters(List<ClothsDTO> clothes, FiltersDTO filters)
        {
            if(clothes == null)
            {
                clothes = new List<ClothsDTO>();
                clothes = await _context.Cloth.Include(x => x.Mark).Select(x =>
                    new ClothsDTO
                    {
                        Id = x.Id,
                        Fullname = x.Fullname,
                        Price = x.Price,
                        Img = x.Img,
                        Discount = x.Discount,
                        Mark_Name = x.Mark.MarkName,
                        Category_Id = x.Category_Id,
                        Mark_Id = x.Mark_Id,
                        Gender_Id = x.Gender_Id
                    }
                ).AsSplitQuery().AsNoTracking().ToListAsync();
            }
            if (clothes == null) throw new MyException();
            if (filters.Category_Id != 0)
            {
                clothes = (from i in clothes where i.Category_Id == filters.Category_Id select i).ToList();
            }
            if(filters.Mark_Id != 0)
            {
                clothes = (from i in clothes where i.Mark_Id == filters.Mark_Id select i).ToList();
            }
            if (filters.Gender_Id != 0)
            {
                clothes = (from i in clothes where i.Gender_Id == filters.Gender_Id select i).ToList();
            }
            int Discount = (filters.Discount == true) ? 1 : 0;
            if (filters.MaxPrice == 0) filters.MaxPrice = 10000;
            clothes = (from i in clothes where i.Discount >= Discount && i.Price <= filters.MaxPrice select i).ToList();
            return clothes;
        }

        public async Task<List<ClothsDTO>> GetSearchedClothes(string name)
        {
            var clothes = await _context.Cloth.Include(x => x.Mark).Where(x => x.Fullname.Contains(name)).Select(x => 
                new ClothsDTO
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Price = x.Price,
                    Img = x.Img,
                    Discount = x.Discount,
                    Mark_Name = x.Mark.MarkName,
                    Mark_Id = x.Mark_Id,
                    Category_Id = x.Category_Id,
                    Gender_Id = x.Gender_Id
                }
            ).AsSplitQuery().AsNoTracking().ToListAsync();
            return clothes;
        }
    }
}
