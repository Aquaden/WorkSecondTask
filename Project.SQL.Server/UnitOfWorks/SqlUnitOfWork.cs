using Project.Repository.Repositories.ProductRepositories;
using Project.Repository.UnitOfWorks;
using Project.SQL.Server.DbContexts;
using Project.SQL.Server.Infrastructure;

namespace Project.SQL.Server.UnitOfWorks;

public class SqlUnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly AppDbContext _context;

    public SqlUnitOfWork(AppDbContext appDbContext)
    {
  
            
    }
    public SqlProductRepository _productRepo;
    public IProductRepository ProductRepository => _productRepo ??= new SqlProductRepository(_connectionString, _context);

    public async Task SaveChanegsAsync()
    {
        await _context.SaveChangesAsync();
    }
}
