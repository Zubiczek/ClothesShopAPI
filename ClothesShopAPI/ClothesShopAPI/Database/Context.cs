using ClothesShopAPI.Database.Entities;
using ClothesShopAPI.Database.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
        public DbSet<ClothCategoryEntity> ClothCategory { get; set; }
        public DbSet<ClothCommentsEntity> ClothComments { get; set; }
        public DbSet<ClothEntity> Cloth { get; set; }
        public DbSet<ClothMarkEntity> ClothMark { get; set; }
        public DbSet<ClothOpinionsEntity> ClothOpinions { get; set; }
        public DbSet<ClothSizeEntity> ClothSize { get; set; }
        public DbSet<GenderEntity> Gender { get; set; }
        public DbSet<OrderClothesEntity> OrderClothes { get; set; }
        public DbSet<OrdersEntity> Orders { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        public DbSet<SizeEntity> Size { get; set; }
        public DbSet<UserBasketEntity> UserBasket { get; set; }
        public DbSet<UserEntity> User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurations();
        }
    }
}
