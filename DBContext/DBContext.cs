using EcommerceClothes.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClothes.DBContext
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineOfOrder> LinesOfOrder { get; set; }
        public DbSet<Product> Products { get; set; }


        //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    LastName = "Perez",
                    Name = "Pablo",
                    Email = "pperez@gmail.com",
                    UserName = "pperez",
                    Password = "123456",
                    Address = "Mendoza 6000",
                    Id = 1
                },
                new Client
                {
                    LastName = "Rodriguez",
                    Name = "Joaquin",
                    Email = "jrodriguez@gmail.com",
                    UserName = "jrodriguez",
                    Password = "123456",
                    Address = "Corrientes 500",
                    Id = 2
                },
                new Client
                {
                    LastName = "Tonini",
                    Name = "Javier",
                    Email = "tjavier@gmail.com",
                    UserName = "tjavier",
                    Password = "123456",
                    Address = "Pellegini 4000",
                    Id = 3
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    LastName = "Ruiz",
                    Name = "Francisco",
                    Email = "fruiz@gmail.com",
                    UserName = "fruiz",
                    Password = "123456",
                    Id = 4,
                    Role = "admin"
                },
                new Admin
                {
                    LastName = "Sueiro",
                    Name = "Sebastian",
                    Email = "ssueiro@gmail.com",
                    UserName = "ssueiro",
                    Password = "123456",
                    Id = 5,
                    Role = "admin"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 6,
                    Name = "Remera azul marino",
                    Price = 8500,
                    Stock = 8,

                },
                new Product
                {
                    Id = 7,
                    Name = "Buzo negro",
                    Price = 15000,
                    Stock = 5,
                });



            // Relación entre Cliente y OrdenDeVenta (uno a muchos)
            modelBuilder.Entity<Client>()
           .HasMany(c => c.Orders)
           .WithOne(o => o.Client)
           .HasForeignKey(o => o.ClientId);

            // Relación entre OrdenDeVenta y LineaDeVenta (uno a muchos)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.LinesOfOrder)
                .WithOne(l => l.SaleOrder)
                .HasForeignKey(l => l.SaleOrderId);


            modelBuilder.Entity<LineOfOrder>()
                .HasOne(sol => sol.Product)
                .WithMany() //vacío porque no me interesa establecer esa relación
                .HasForeignKey(sol => sol.ProductId);



            base.OnModelCreating(modelBuilder);

        }
    }
}
