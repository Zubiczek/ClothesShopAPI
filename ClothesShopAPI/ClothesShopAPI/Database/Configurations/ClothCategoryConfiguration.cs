using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class ClothCategoryConfiguration : IEntityTypeConfiguration<ClothCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ClothCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
