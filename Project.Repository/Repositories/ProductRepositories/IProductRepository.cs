using Project.Domain.Entities;

namespace Project.Repository.Repositories.ProductRepositories;

public interface IProductRepository
{
    public IQueryable<Product> GetAllProducts();
    public void UpdateProduct(Product product);
    public Task AddProduct(Product entity);
    public Task<Product> GetById(int id);
    
    public void DeleteProudct(int id);
}
