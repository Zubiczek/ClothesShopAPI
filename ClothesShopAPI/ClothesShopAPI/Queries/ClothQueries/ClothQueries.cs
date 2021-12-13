using ClothesShopAPI.Database;
using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.Others;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.ClothQueries
{
    public class ClothQueries : IGetClothQueries
    {
        private readonly Context _context;
        public ClothQueries(Context context)
        {
            _context = context;
        }
        public async Task<List<ClothsDTO>> GetAllClothes()
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
            ).AsSplitQuery().AsNoTracking().ToListAsync();
            return clothes;
        }
        public async Task<List<ClothsDTO>> GetClothsWithDiscount()
        {
            var clothes = await _context.Cloth.Include(x => x.Mark).Where(x => x.Discount != 0).Select(x =>
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
        public async Task<List<ClothsDTO>> GetClothByGender(string gender)
        {
            var clothes = await _context.Cloth.Include(x => x.Mark).Where(x => x.Gender.Name == gender).Select(x =>
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
        public async Task<List<ClothsDTO>> GetClothByCategory(string category)
        {
            var clothes = await _context.Cloth.Include(x => x.Mark).Where(x => x.Category.CategoryName == category).Select(x =>
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
        public async Task<List<ClothsDTO>> GetClothByMark(string mark)
        {
            var clothes = await _context.Cloth.Include(x => x.Mark).Where(x => x.Mark.MarkName == mark).Select(x =>
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
        public async Task<ClothDTO> GetClothById(int id)
        {
            var cloth = await _context.Cloth.Include(x => x.Category).Include(x => x.Mark).Include(x => x.Gender).
                Include(x => x.Opinions).Where(x => x.Id == id).Select(x =>
                new ClothDTO
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Price = x.Price,
                    Img = x.Img,
                    IsItInStock = x.IsItInStock,
                    Description = x.Description,
                    Discount = x.Discount,
                    Gender_Name = x.Gender.Name,
                    Mark_Name = x.Mark.MarkName,
                    Category_Name = x.Category.CategoryName,
                    Opinion = new OpinionDTO
                    {
                        OpinionSum = x.Opinions.OpinionSum,
                        UserSum = x.Opinions.UserSum
                    }
                }
                ).AsSplitQuery().AsNoTracking().FirstOrDefaultAsync();
            if (cloth == null) throw new MyException(401);
            return cloth;
        }
    }
}
