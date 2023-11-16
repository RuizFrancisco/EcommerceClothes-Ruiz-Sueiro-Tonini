using EcommerceClothes.Entities;
using EcommerceClothes.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

namespace EcommerceClothes.DBContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<LineOfOrder> LinesOfOrder { get; set; }
        public DbSet<Product> Products { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasDiscriminator<UserType>("UserType")
                .HasValue<Admin>(UserType.Admin)
                .HasValue<Client>(UserType.Client);

            modelBuilder.Entity<Client>().HasData( 
            new Client
            {
                Id = 1,
                Email = "pedro@gmail.com",
                UserName = "PedroSanchez",
                Password = "1234"

            },
            new Client
            {
                Id = 2,
                Email = "mariano@gmail.com",
                UserName = "MarianoRajoy",
                Password = "1234"
            },
            new Client
            {
                Id = 3,
                Email = "franco@gmail.com",
                UserName = "Franco",
                Password = "1234"
            }
            );

            modelBuilder.Entity<Admin>().HasData( 
            new Admin
            {
                Id = 4,
                Email = "francisco@gmail.com",
                UserName = "AdminFran",
                Password = "1234"
            });

            modelBuilder.Entity<Product>().HasData( 
            new Product
            {
                Id = 1,
                Name = "Remera",
                Description = "Remera azul marino",
                Price = 8000
            },
            new Product
            {
                Id = 2,
                Name = "Campera",
                Description = "Campera negra",
                Price = 18000
            }
            );

            modelBuilder.Entity<Client>(entity => 
            {   
                entity.ToTable("Users"); 
                entity.HasMany(c => c.Orders) 
                    .WithOne(p => p.Client) 
                    .HasForeignKey(p => p.ClientId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.Id);
                entity.HasMany(p => p.LinesOfOrder)
                    .WithOne(pl => pl.Order)
                    .HasForeignKey(pl => pl.OrderId);
            });

            modelBuilder.Entity<LineOfOrder>(entity =>
            {
                entity.ToTable("SaleLines");
                entity.HasKey(e => e.Id);
                entity.HasOne(pl => pl.Product)
                    .WithMany(p => p.LinesOfOrder)
                    .HasForeignKey(pl => pl.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
                entity.HasMany(p => p.LinesOfOrder)
                    .WithOne(pl => pl.Product)
                    .HasForeignKey(pl => pl.ProductId);
            });

           
            base.OnModelCreating(modelBuilder);
        }
    }
}
