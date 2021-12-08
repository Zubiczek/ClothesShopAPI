using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class ClothMarkConfiguration : IEntityTypeConfiguration<ClothMarkEntity>
    {
        public void Configure(EntityTypeBuilder<ClothMarkEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
