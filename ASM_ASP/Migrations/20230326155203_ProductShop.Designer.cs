﻿// <auto-generated />
using System;
using ASM_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM_ASP.Migrations
{
    [DbContext(typeof(ShopDBContext))]
    [Migration("20230326155203_ProductShop")]
    partial class ProductShop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASM_ASP.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ASM_ASP.Models.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdBill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBill");

                    b.HasIndex("IdProduct");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("ASM_ASP.Models.Cart", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ASM_ASP.Models.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("UserId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("ASM_ASP.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("ASM_ASP.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("ASM_ASP.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("IdColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdMaterial")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSize")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdMaterial");

                    b.HasIndex("IdSize");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ASM_ASP.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SizeOfShoe")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("ASM_ASP.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASM_ASP.Models.Bill", b =>
                {
                    b.HasOne("ASM_ASP.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_ASP.Models.BillDetail", b =>
                {
                    b.HasOne("ASM_ASP.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdBill")
                        .HasConstraintName("FK_Bill");

                    b.HasOne("ASM_ASP.Models.Product", "Product")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdProduct")
                        .HasConstraintName("FK_Product");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASM_ASP.Models.Cart", b =>
                {
                    b.HasOne("ASM_ASP.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("ASM_ASP.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_ASP.Models.CartDetail", b =>
                {
                    b.HasOne("ASM_ASP.Models.Product", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdProduct");

                    b.HasOne("ASM_ASP.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("UserId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASM_ASP.Models.Product", b =>
                {
                    b.HasOne("ASM_ASP.Models.Color", "Color")
                        .WithMany("Products")
                        .HasForeignKey("IdColor")
                        .HasConstraintName("FK_Color");

                    b.HasOne("ASM_ASP.Models.Material", "Material")
                        .WithMany("Products")
                        .HasForeignKey("IdMaterial")
                        .HasConstraintName("FK_Material");

                    b.HasOne("ASM_ASP.Models.Size", "Size")
                        .WithMany("Products")
                        .HasForeignKey("IdSize")
                        .HasConstraintName("FK_Size");

                    b.Navigation("Color");

                    b.Navigation("Material");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ASM_ASP.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("ASM_ASP.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("ASM_ASP.Models.Color", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_ASP.Models.Material", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_ASP.Models.Product", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("ASM_ASP.Models.Size", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_ASP.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
