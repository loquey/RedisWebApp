// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RedisMvcApp.Persistence;

#nullable disable

namespace RedisMvcApp.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Products")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductCategory", b =>
                {
                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModifed")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories", "Products");
                });

            modelBuilder.Entity("RedisMvcApp.Persistence.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModifed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("SKU")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId");

                    b.ToTable("Product", "Products");
                });

            modelBuilder.Entity("RedisMvcApp.Persistence.Entities.ProductSeller", b =>
                {
                    b.Property<Guid>("ProductSellerId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModifed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductSellerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSeller", "Products");
                });

            modelBuilder.Entity("RedisMvcApp.Persistence.Entities.ProductSeller", b =>
                {
                    b.HasOne("RedisMvcApp.Persistence.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
