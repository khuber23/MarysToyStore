﻿// <auto-generated />
using System;
using MarysToyStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarysToyStore.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230426015625_AddedAddress")]
    partial class AddedAddress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarysToyStore.DataAccess.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsArchived = false,
                            Name = "Mattel"
                        },
                        new
                        {
                            Id = 2,
                            IsArchived = false,
                            Name = "Fisher Price"
                        },
                        new
                        {
                            Id = 3,
                            IsArchived = false,
                            Name = "Hot Wheels"
                        });
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 3,
                            Description = "A toy car that goes really fast.",
                            ImagePath = "/bluecar.jpg",
                            IsArchived = false,
                            Name = "Car",
                            Price = 3.99m
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Description = "Toy ducks that float.",
                            ImagePath = "/ducks.jpg",
                            IsArchived = false,
                            Name = "Ducks",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Description = "A toy to build your ideas.",
                            ImagePath = "/legos.jpg",
                            IsArchived = false,
                            Name = "Legos",
                            Price = 25.99m
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            Description = "An advanced toy that will make anybody happy.",
                            ImagePath = "/robot.jpg",
                            IsArchived = false,
                            Name = "Robot",
                            Price = 15.99m
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            Description = "A soft bear that is comforting to touch.",
                            ImagePath = "/teddy.jpg",
                            IsArchived = false,
                            Name = "Teddy",
                            Price = 29.99m
                        });
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsArchived = false,
                            Name = "Sporting Goods"
                        },
                        new
                        {
                            Id = 2,
                            IsArchived = false,
                            Name = "Home"
                        },
                        new
                        {
                            Id = 3,
                            IsArchived = false,
                            Name = "Office"
                        },
                        new
                        {
                            Id = 4,
                            IsArchived = false,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 5,
                            IsArchived = false,
                            Name = "Electronics"
                        });
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.ProductCategoryProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ProductCategoryId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductCategoriesProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductCategoryId = 3
                        },
                        new
                        {
                            ProductId = 1,
                            ProductCategoryId = 5
                        });
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.CartItem", b =>
                {
                    b.HasOne("MarysToyStore.DataAccess.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarysToyStore.DataAccess.User", "User")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Order", b =>
                {
                    b.HasOne("MarysToyStore.DataAccess.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.OrderLine", b =>
                {
                    b.HasOne("MarysToyStore.DataAccess.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarysToyStore.DataAccess.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Product", b =>
                {
                    b.HasOne("MarysToyStore.DataAccess.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.ProductCategoryProduct", b =>
                {
                    b.HasOne("MarysToyStore.DataAccess.ProductCategory", "ProductCategory")
                        .WithMany("ProductCategoryProducts")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarysToyStore.DataAccess.Product", "Product")
                        .WithMany("ProductCategoryProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderLines");

                    b.Navigation("ProductCategoryProducts");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.ProductCategory", b =>
                {
                    b.Navigation("ProductCategoryProducts");
                });

            modelBuilder.Entity("MarysToyStore.DataAccess.User", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
