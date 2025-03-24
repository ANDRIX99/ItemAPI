﻿// <auto-generated />
using ItemAPI.Controllers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItemAPI.Migrations
{
    [DbContext(typeof(ItemDbContext))]
    [Migration("20250324132428_ItemDetailRelationship")]
    partial class ItemDetailRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemAPI.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Pasta"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Farina"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Acqua"
                        });
                });

            modelBuilder.Entity("ItemAPI.Model.ItemDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique()
                        .HasFilter("[ItemId] IS NOT NULL");

                    b.ToTable("ItemDetails");
                });

            modelBuilder.Entity("ItemAPI.Model.ItemDetail", b =>
                {
                    b.HasOne("ItemAPI.Model.Item", "Item")
                        .WithOne("ItemDetail")
                        .HasForeignKey("ItemAPI.Model.ItemDetail", "ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ItemAPI.Model.Item", b =>
                {
                    b.Navigation("ItemDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
