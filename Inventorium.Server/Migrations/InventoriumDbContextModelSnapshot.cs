﻿// <auto-generated />
using System;
using Inventorium.Server.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventorium.Server.Migrations
{
    [DbContext(typeof(InventoriumDbContext))]
    partial class InventoriumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inventorium.Server.Model.LocalVariationQuantity", b =>
                {
                    b.Property<int>("LocalVariationQuantityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalVariationQuantityId"), 1L, 1);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("VariationId")
                        .HasColumnType("int");

                    b.HasKey("LocalVariationQuantityId");

                    b.HasIndex("LocationId");

                    b.HasIndex("VariationId");

                    b.ToTable("LocalVariationQuantities");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Variation", b =>
                {
                    b.Property<int>("VariationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VariationId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Sku")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("bit");

                    b.HasKey("VariationId");

                    b.HasIndex("ProductId");

                    b.ToTable("Variations");
                });

            modelBuilder.Entity("Inventorium.Server.Model.LocalVariationQuantity", b =>
                {
                    b.HasOne("Inventorium.Server.Model.Location", "Location")
                        .WithMany("LocalVariationQuantities")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventorium.Server.Model.Variation", "Variation")
                        .WithMany("LocalVariationQuantities")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Variation", b =>
                {
                    b.HasOne("Inventorium.Server.Model.Product", null)
                        .WithMany("Variations")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Location", b =>
                {
                    b.Navigation("LocalVariationQuantities");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Product", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("Inventorium.Server.Model.Variation", b =>
                {
                    b.Navigation("LocalVariationQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}
