using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedisMvcApp.Persistence.Entities;

static class BaseEntityConfiguration
{
    static public void Configure<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
    {
        builder.Property(k => k.DateAdded)
            .IsRequired();
        builder.Property(p => p.LastModifed)
            .IsRequired(false);
    }
}