﻿// <auto-generated />
using System;
using CarRent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRent.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("CarRent.Models.Entities.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("daily_price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SaleID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Rental", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("from_date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("to_date")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("UserID");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("percent")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CarRent.Models.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Car", b =>
                {
                    b.HasOne("CarRent.Models.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.Models.Entities.Sale", "Sale")
                        .WithMany("Cars")
                        .HasForeignKey("SaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Rental", b =>
                {
                    b.HasOne("CarRent.Models.Entities.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.Models.Entities.User", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Car", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRent.Models.Entities.Sale", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRent.Models.Entities.User", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
