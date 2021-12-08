using ClothesShopAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<OrdersEntity>
    {
        public void Configure(EntityTypeBuilder<OrdersEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithOne(x => x.Order).HasForeignKey<OrdersEntity>(x => x.User_Id);
        }
    }
}
