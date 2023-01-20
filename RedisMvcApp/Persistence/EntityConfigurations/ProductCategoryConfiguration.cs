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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(k => k.ProductCategoryId);
            builder.Property(p => p.CategoryDescription)
                .HasMaxLength(300)
                .IsUnicode();
            builder.Property(p => p.CategoryName)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();
            BaseEntityConfiguration.Configure(builder);
        }
    }
}
