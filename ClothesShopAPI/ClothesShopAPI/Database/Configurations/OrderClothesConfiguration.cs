using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class OrderClothesConfiguration : IEntityTypeConfiguration<OrderClothesEntity>
    {
        public void Configure(EntityTypeBuilder<OrderClothesEntity> builder)
        {
            builder.HasKey(x => new { x.Cloth_Id, x.Order_Id });
            builder.HasOne(x => x.Order).WithMany(x => x.Clothes).HasForeignKey(x => x.Order_Id);
            builder.HasOne(x => x.Cloth).WithMany(x => x.Orders).HasForeignKey(x => x.Cloth_Id);
        }
    }
}
