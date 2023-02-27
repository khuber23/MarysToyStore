﻿// <auto-generated />
<<<<<<< HEAD
using System;
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
using MarysToyStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarysToyStore.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

<<<<<<< HEAD
            modelBuilder.Entity("MarysToyStore.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mattel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fisher Price"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hot Wheels"
                        });
                });

=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
            modelBuilder.Entity("MarysToyStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

<<<<<<< HEAD
                    b.Property<int?>("BrandId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
=======
                    b.Property<string>("Description")
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
<<<<<<< HEAD
                        .IsRequired()
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

<<<<<<< HEAD
                    b.HasIndex("BrandId");

=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
<<<<<<< HEAD
                            BrandId = 3,
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                            Description = "A toy car that goes really fast.",
                            ImagePath = "/bluecar.jpg",
                            Name = "Car",
                            Price = 3.99m
                        },
                        new
                        {
                            Id = 2,
<<<<<<< HEAD
                            BrandId = 1,
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                            Description = "Toy ducks that float.",
                            ImagePath = "/ducks.jpg",
                            Name = "Ducks",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 3,
<<<<<<< HEAD
                            BrandId = 1,
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                            Description = "A toy to build your ideas.",
                            ImagePath = "/legos.jpg",
                            Name = "Legos",
                            Price = 25.99m
                        },
                        new
                        {
                            Id = 4,
<<<<<<< HEAD
                            BrandId = 1,
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                            Description = "An advanced toy that will make anybody happy.",
                            ImagePath = "/robot.jpg",
                            Name = "Robot",
                            Price = 15.99m
                        },
                        new
                        {
                            Id = 5,
<<<<<<< HEAD
                            BrandId = 2,
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
                            Description = "A soft bear that is comforting to touch.",
                            ImagePath = "/teddy.jpg",
                            Name = "Teddy",
                            Price = 29.99m
                        });
                });
<<<<<<< HEAD

            modelBuilder.Entity("MarysToyStore.Models.Product", b =>
                {
                    b.HasOne("MarysToyStore.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("MarysToyStore.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });
=======
>>>>>>> b5f555990d3dc0429685036e54860cd504192632
#pragma warning restore 612, 618
        }
    }
}