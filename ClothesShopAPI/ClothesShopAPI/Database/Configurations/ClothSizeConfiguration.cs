using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class ClothSizeConfiguration : IEntityTypeConfiguration<ClothSizeEntity>
    {
        public void Configure(EntityTypeBuilder<ClothSizeEntity> builder)
        {
            builder.HasKey(x => new { x.Cloth_Id, x.Size_Id });
            builder.HasOne(x => x.Cloth).WithMany(x => x.ClothSizes).HasForeignKey(x => x.Cloth_Id);
            builder.HasOne(x => x.Size).WithMany(x => x.ClothSizes).HasForeignKey(x => x.Size_Id);
        }
    }
}
