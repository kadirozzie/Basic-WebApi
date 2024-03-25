using Microsoft.EntityFrameworkCore;
using urunTakip.DataAccessLayer;

namespace urunTakip
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); 
        }
        public DbSet<Product> Products { get; set; }


        //decimal uyarısı için 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.TaxRatio)
                .HasColumnType("decimal(18,2)");
        }
        // decimal uyarısı için


    }
}
