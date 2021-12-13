using AutoMapper;
using ClothesShopAPI.Database;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.GetDTO;
using ClothesShopAPI.Models.DTO.PostDTO;
using ClothesShopAPI.Models.Others;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Queries.OpinionQueries
{
    public class OpinionQueries : IOpinionQueries
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public OpinionQueries(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddOpinion(AddOpinionDTO opinion, string userid)
        {
            if (opinion == null) throw new MyException(400);
            UserOpinionEntity newopinion = _mapper.Map<UserOpinionEntity>(opinion);
            newopinion.User_Id = userid;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Add(newopinion);
                    await _context.SaveChangesAsync();
                    var opin = await _context.ClothOpinions.Where(x => x.Id == opinion.Opinion_Id).FirstOrDefaultAsync();
                    if (opin == null) throw new MyException(401);
                    opin.OpinionSum += opinion.Value;
                    opin.UserSum += 1;
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new MyException();
                }
            }
        }
    }
}
