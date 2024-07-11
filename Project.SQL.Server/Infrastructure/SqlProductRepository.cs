using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Repository.Repositories.ProductRepositories;
using Project.SQL.Server.DbContexts;

namespace Project.SQL.Server.Infrastructure;

public class SqlProductRepository : BaseSqlRepository, IProductRepository
{
    private readonly AppDbContext _context;

    public SqlProductRepository(string connectionString, AppDbContext context) : base(connectionString)
    {
        _context = context;

    }

    public async Task AddProduct(Product entity)
    {
        await _context.AddAsync(entity);
    }


    public void DeleteProudct(int id)
    {
        var prod = _context.Products.FirstOrDefault(b => b.Id == id);
        prod.IsDeleted = true;
        prod.Deleted_date = DateTime.Now;
    }

    public IQueryable<Product> GetAllProducts()
    {
        var data = _context.Products.AsNoTracking().OrderByDescending(b => b.Created_date).Where(b => b.IsDeleted == false);
        return data;
    }

    public async Task<Product> GetById(int id)
    {
        var data = await _context.Products.FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted == false);
        return data;
    }

    public void UpdateProduct(Product product)
    {
        var data = _context.Products.FirstOrDefaultAsync(b => b.Id == product.Id && b.IsDeleted == false);
        product.Updated_date = DateTime.Now;
        _context.Products.Update(product);
    }
}
