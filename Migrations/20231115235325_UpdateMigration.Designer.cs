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
    [DbContext(typeof(DBContext.DBContext))]
    [Migration("20231115235325_UpdateMigration")]
    partial class UpdateMigration
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

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleLines", (string)null);
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LineOfOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("LineOfOrderId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Remera azul marino",
                            Name = "Remera",
                            Price = 8000f
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Admin", b =>
                {
                    b.HasBaseType("EcommerceClothes.Entities.User");

                    b.HasDiscriminator().HasValue(0);

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "francisco@gmail.com",
                            Password = "1234",
                            UserName = "AdminFran",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Client", b =>
                {
                    b.HasBaseType("EcommerceClothes.Entities.User");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pedro@gmail.com",
                            Password = "1234",
                            UserName = "PedroSanchez",
                            UserType = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "mariano@gmail.com",
                            Password = "1234",
                            UserName = "MarianoRajoy",
                            UserType = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "franco@gmail.com",
                            Password = "1234",
                            UserName = "Franco",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("EcommerceClothes.Entities.LineOfOrder", b =>
                {
                    b.HasOne("EcommerceClothes.Entities.Order", "Order")
                        .WithMany("LinesOfOrder")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceClothes.Entities.Product", "Product")
                        .WithMany("LinesOfOrder")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
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

            modelBuilder.Entity("EcommerceClothes.Entities.Product", b =>
                {
                    b.HasOne("EcommerceClothes.Entities.LineOfOrder", null)
                        .WithMany("Products")
                        .HasForeignKey("LineOfOrderId");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.LineOfOrder", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Order", b =>
                {
                    b.Navigation("LinesOfOrder");
                });

            modelBuilder.Entity("EcommerceClothes.Entities.Product", b =>
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
