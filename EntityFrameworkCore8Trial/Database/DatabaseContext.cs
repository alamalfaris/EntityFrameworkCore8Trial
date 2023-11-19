using EntityFrameworkCore8Trial.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore8Trial.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(m => m.Id);
            });
        }
    }
}
