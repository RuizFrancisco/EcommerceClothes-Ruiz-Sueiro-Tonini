﻿// <auto-generated />
using System;
using EcommerceClothes.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceClothes.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    [Migration("20240222213703_QuintaMigracion")]
    partial class QuintaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("EcommerceClothes.Entities.LineOfOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleOrderId");

                    b.ToTable("LinesOfOrder");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Name = "Remera azul marino",
                            Price = 8500m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 7,
                            Name = "Buzo negro",
                            Price = 15000m,
                            Stock = 5
                        });
                });

            modelBuilder.Entity("EcommerceClothes.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Admin", b =>
                {
                    b.HasBaseType("EcommerceClothes.Entities.User");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "fruiz@gmail.com",
                            LastName = "Ruiz",
                            Name = "Francisco",
                            Password = "123456",
                            State = true,
                            UserName = "fruiz",
                            Role = "admin"
                        },
                        new
                        {
                            Id = 5,
                            Email = "ssueiro@gmail.com",
                            LastName = "Sueiro",
                            Name = "Sebastian",
                            Password = "123456",
                            State = true,
                            UserName = "ssueiro",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Client", b =>
                {
                    b.HasBaseType("EcommerceClothes.Entities.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pperez@gmail.com",
                            LastName = "Perez",
                            Name = "Pablo",
                            Password = "123456",
                            State = true,
                            UserName = "pperez",
                            Address = "Mendoza 6000"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jrodriguez@gmail.com",
                            LastName = "Rodriguez",
                            Name = "Joaquin",
                            Password = "123456",
                            State = true,
                            UserName = "jrodriguez",
                            Address = "Corrientes 500"
                        },
                        new
                        {
                            Id = 3,
                            Email = "tjavier@gmail.com",
                            LastName = "Tonini",
                            Name = "Javier",
                            Password = "123456",
                            State = true,
                            UserName = "tjavier",
                            Address = "Pellegini 4000"
                        });
                });

            modelBuilder.Entity("EcommerceClothes.Entities.LineOfOrder", b =>
                {
                    b.HasOne("EcommerceClothes.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceClothes.Entities.Order", "SaleOrder")
                        .WithMany("LinesOfOrder")
                        .HasForeignKey("SaleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleOrder");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Order", b =>
                {
                    b.HasOne("EcommerceClothes.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Order", b =>
                {
                    b.Navigation("LinesOfOrder");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
