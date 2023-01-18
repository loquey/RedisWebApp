﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RedisMvcApp.Persistence;

#nullable disable

namespace RedisMvcApp.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230117012753_Initil migration")]
    partial class Initilmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductCategory", b =>
                {
                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModifed")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}