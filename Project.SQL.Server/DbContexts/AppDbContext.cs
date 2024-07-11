using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.EntityConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
