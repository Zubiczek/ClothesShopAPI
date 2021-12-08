using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class ClothOpinionsConfiguration : IEntityTypeConfiguration<ClothOpinionsEntity>
    {
        public void Configure(EntityTypeBuilder<ClothOpinionsEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Opinions).HasForeignKey(x => x.User_Id);
        }
    }
}
