using Microsoft.EntityFrameworkCore;
using ProyectoEstructura.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.Repositories.EFCore.DataContext
{
    public class ProyectoEstructuraContext : DbContext
    {
        public ProyectoEstructuraContext(
            DbContextOptions<ProyectoEstructuraContext> options) :
            base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Order>()
                .Property(o => o.CostumerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Order>()
             .Property(o => o.ShipCity)        
             .HasMaxLength(15);

            modelBuilder.Entity<Order>()
             .Property(o => o.ShipCountry)
             .HasMaxLength(15);

            modelBuilder.Entity<Order>()
            .Property(o => o.ShipPostalCode)
            .HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(O => O.CostumerId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id=1, Name="Product 1"},
                new Product { Id=2, Name="Product 2" },
                new Product { Id=3,Name="Product 3" },
                new Product { Id= 4, Name = "Product 4" }

                );

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id="RACS", Name="RAUL CUDRIS SINNING"},
                new Customer { Id = "FNR", Name = "FREDDY NAVARRO RODRIGUEZ" },
                new Customer { Id = "JCBJ", Name = "JOSE BARRIOS JIMENEZ" }
                );


        }

    }
}
