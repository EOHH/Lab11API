using Microsoft.EntityFrameworkCore;

namespace Lab11API.Models
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=APISemana11ADB; Integrated Security=True; Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>()
                .Property(d => d.Price)
                .HasColumnType("decimal(18,2)"); // Especifica el tipo de columna con precisión

            modelBuilder.Entity<Detail>()
                .Property(d => d.Subtotal)
                .HasColumnType("decimal(18,2)"); // Especifica el tipo de columna con precisión

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Total)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
