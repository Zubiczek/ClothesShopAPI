using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class UserBasketConfiguration : IEntityTypeConfiguration<UserBasketEntity>
    {
        public void Configure(EntityTypeBuilder<UserBasketEntity> builder)
        {
            builder.HasKey(x => new { x.Cloth_Id, x.User_Id, x.Size_Id });
            builder.HasOne(x => x.Cloth).WithMany(x => x.Baskets).HasForeignKey(x => x.Cloth_Id);
            builder.HasOne(x => x.User).WithMany(x => x.BasketClothes).HasForeignKey(x => x.User_Id);
            builder.HasOne(x => x.Size).WithMany(x => x.Baskets).HasForeignKey(x => x.Size_Id);
        }
    }
}
