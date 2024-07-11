using Project.Repository.Repositories.ProductRepositories;

namespace Project.Repository.UnitOfWorks;

public interface IUnitOfWork
{
    
    public IProductRepository ProductRepository { get; }
    Task SaveChanegsAsync();
}
