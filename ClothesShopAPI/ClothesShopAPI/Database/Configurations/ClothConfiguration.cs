using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class ClothConfiguration : IEntityTypeConfiguration<ClothEntity>
    {
        public void Configure(EntityTypeBuilder<ClothEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Category).WithMany(x => x.Clothes).HasForeignKey(x => x.Category_Id);
            builder.HasOne(x => x.Mark).WithMany(x => x.Clothes).HasForeignKey(x => x.Mark_Id);
            builder.HasOne(x => x.Gender).WithMany(x => x.Clothes).HasForeignKey(x => x.Gender_Id);
            builder.HasOne(x => x.Opinions).WithOne(x => x.Cloth).HasForeignKey<ClothEntity>(x => x.Opinion_Id);        }
    }
}
