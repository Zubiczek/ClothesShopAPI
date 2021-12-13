using AutoMapper;
using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Models.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserDTO, UserEntity>();
                cfg.CreateMap<AddOpinionDTO, UserOpinionEntity>();
                cfg.CreateMap<AddCommentDTO, ClothCommentsEntity>();
                cfg.CreateMap<NewAddressDTO, UserEntity>();
                cfg.CreateMap<AddToBasketDTO, UserBasketEntity>();
            }).CreateMapper();
    }
}
