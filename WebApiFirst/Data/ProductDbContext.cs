using Microsoft.EntityFrameworkCore;
using WebApiFirst.Entities;

namespace WebApiFirst.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Price = 100, Discount = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 150, Discount = 15 },
                new Product { Id = 3, Name = "Product 3", Price = 200, Discount = 20 },
                new Product { Id = 4, Name = "Product 4", Price = 250, Discount = 25},
                new Product { Id = 5, Name = "Product 5", Price = 300, Discount = 30 },
                new Product { Id = 6, Name = "Product 6", Price = 350, Discount = 35 },
                new Product { Id = 7, Name = "Product 7", Price = 400, Discount = 40 },
                new Product { Id = 8, Name = "Product 8", Price = 450, Discount = 45 },
                new Product { Id = 9, Name = "Product 9", Price = 500, Discount = 50 },
                new Product { Id = 10, Name = "Product 10", Price = 550, Discount = 55 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John", Surname = "Doe" },
                new Customer { Id = 2, Name = "Jane", Surname = "Smith" },
                new Customer { Id = 3, Name = "Mike", Surname = "Johnson" },
                new Customer { Id = 4, Name = "Emily", Surname = "Davis" },
                new Customer { Id = 5, Name = "Sarah", Surname = "Brown" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = DateTime.Now, ProductId = 1, CustomerId = 1 },
                new Order { Id = 2, OrderDate = DateTime.Now, ProductId = 2, CustomerId = 2 },
                new Order { Id = 3, OrderDate = DateTime.Now, ProductId = 3, CustomerId = 3 },
                new Order { Id = 4, OrderDate = DateTime.Now, ProductId = 4, CustomerId = 4 },
                new Order { Id = 5, OrderDate = DateTime.Now, ProductId = 5, CustomerId = 5 }
            );
        }
    }
}
