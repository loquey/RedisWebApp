using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RedisMvcApp.Persistence.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMvcApp.Persistence.EntityConfigurations
{
    internal class ProductSellerConfiguration : IEntityTypeConfiguration<ProductSeller>
    {
        public void Configure(EntityTypeBuilder<ProductSeller> builder)
        {
            builder.HasKey(k => k.ProductSellerId);
            builder.Property(p => p.ProductQuantity).IsRequired()
                .HasConversion<Quantity.EfCoreValueConverter>();
            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
