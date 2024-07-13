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
        _context = appDbContext;
  
            
    }
    public SqlProductRepository _productRepo;
    public IProductRepository ProductRepository => _productRepo ??= new SqlProductRepository(_connectionString, _context);

    public async Task<bool> SaveChanegsAsync()
    {
        //geriye success ve ya false degeri qaytarsin. Databse dusub dusmemiyi deqiq olsun// 0,1.-1
        var rows = await _context.SaveChangesAsync();
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
