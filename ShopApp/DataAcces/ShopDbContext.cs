using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAcces
{
    internal class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ShopComputer");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Electronicos"),
                new Category(2, "Computadoras"),
                new Category(3, "Telefonos Moviles"),
                new Category(4, "Dispositivos de Escritorio"),
                new Category(5, "Microfonos y Audio"),
                new Category(6, "Artefactos del Hogar"),
                new Category(7, "Juguetes y Juegos")
            );

            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Radio Digital", "Es una radio de banda ancha", 100, 1),
                new Product(2, "Reloj electrónico", "Reloj digital sumergible", 50, 1),
                new Product(3, "Laptop HP", "Laptop Escritprio", 900, 2),
                new Product(4, "Laptop Acer", "Laptop Gamer", 1200, 2),
                new Product(5, "Macbook Apple", "Gran Capacidad", 1500, 2),
                new Product(6, "Samsung Galaxy", "Smartphone 5G", 1800, 3),
                new Product(7, "Iphone 14", "Apple disp", 1500, 3)
            );

            modelBuilder.Entity<Client>().HasData(
                new Client(1, "Jose Martinez", "Carrera 1 54 12"),
                new Client(2, "Ronaldo Nazario", "Calle 44 12 32")
            );
        }
    }

    public record Category(int Id, string Nombre);

    public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId)
    {
        public Category Category { get; set; }
    }

    public record Client(int Id, string Nombre, string Direccion);

    // Aquí está la corrección: Agregamos la propiedad Id al final del record
    public record Compra(int ClientId, int ProductId, int Cantidad)
    {
        public int Id { get; set; }
    }
}