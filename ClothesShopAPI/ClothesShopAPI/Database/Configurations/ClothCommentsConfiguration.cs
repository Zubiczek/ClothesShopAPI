using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class ClothCommentsConfiguration : IEntityTypeConfiguration<ClothCommentsEntity>
    {
        public void Configure(EntityTypeBuilder<ClothCommentsEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.User_Id);
            builder.HasOne(x => x.Cloth).WithMany(x => x.Comments).HasForeignKey(x => x.Cloth_Id);
        }
    }
}
