using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.EntityConfigs;

namespace Project.SQL.Server.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products{ get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Product).Assembly);
            modelBuilder.ApplyConfiguration(new ProductConfigure());
            base.OnModelCreating(modelBuilder);
        }
    }
}
