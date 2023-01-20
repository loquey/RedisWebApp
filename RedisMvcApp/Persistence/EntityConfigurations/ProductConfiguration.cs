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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.ProductId);
            builder.Property(p => p.ProductName)
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(true);
            builder.Property(p => p.SKU)
                .IsRequired();
            BaseEntityConfiguration.Configure(builder);
        }
    }
}
