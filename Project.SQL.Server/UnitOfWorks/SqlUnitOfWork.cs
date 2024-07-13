using Microsoft.Extensions.Configuration;
using Project.Repository.Repositories.ProductRepositories;
using Project.Repository.UnitOfWorks;
using Project.SQL.Server.DbContexts;
using Project.SQL.Server.Infrastructure;

namespace Project.SQL.Server.UnitOfWorks;

public class SqlUnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly AppDbContext _context;
    private ProductRepository _productRepo;


    public SqlUnitOfWork(AppDbContext appDbContext, IConfiguration configuration)
    {
        _context = appDbContext;
        _connectionString = configuration.GetConnectionString("MyConnection");
    }
    
    public IProductRepository ProductRepository => _productRepo ??= new ProductRepository(_connectionString, _context);
    
    //
    // public IPaymentRepository PaymentRepository =>
    //     _paymentRepository ??= new PaymentRepository(_connectionString, Context);

    public async Task<bool> SaveChanegsAsync()
    {
        var rows = await _context.SaveChangesAsync();
        if (rows > 0)
            return true;

        return false;
    }
}
