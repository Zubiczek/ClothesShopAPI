using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class UserOpinionConfiguration : IEntityTypeConfiguration<UserOpinionEntity>
    {
        public void Configure(EntityTypeBuilder<UserOpinionEntity> builder)
        {
            builder.HasKey(x => new { x.Opinion_Id, x.User_Id });
            builder.HasOne(x => x.Opinion).WithMany(x => x.UserOpinioned).HasForeignKey(x => x.Opinion_Id);
            builder.HasOne(x => x.User).WithMany(x => x.Opinions).HasForeignKey(x => x.User_Id);
        }
    }
}
