using Dapper;
using Project.Domain.Entities;
using Project.Repository.Repositories.ProductRepositories;
using Project.SQL.Server.DbContexts;

namespace Project.SQL.Server.Infrastructure;

public class ProductRepository : BaseSqlRepository, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(string connectionString, AppDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddProduct(Product entity)
    {
        await using var conn = OpenConnection();

        // var parametrs = new DynamicParameters();
        var sql = @"INSERT INTO product(name,description,created_date,deleted_date,updated_date,is_deleted) 
                   VALUES (@Name,@Description,@Createddate,@DeletedDate,@UpdatedDate,@IsDeleted)";

        await conn.ExecuteScalarAsync(sql, entity);
    }


    public void DeleteProduct(int id)
    {
        var checkSql = "SELECT id from product WHERE id = @Id AND is_deleted=0";

        var sql = "UPDATE product" +
                  "SET is_deleted = 1," +
                  " deleted_date = GETDATE()" +
                  "WHERE id = @Id";
        using var conn = OpenConnection();

        var countId = conn.ExecuteScalar<int>(checkSql, new { id });

        if (countId > 0)
            conn.ExecuteAsync(sql, new { id });
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var sql = "SELECT * FROM vw_product";
        using var conn = OpenConnection();
        var data = conn.Query<Product>(sql);
        return data;
    }

    public async Task<Product> GetById(int id)
    {
        var sql = "SELECT * FROM product WHERE id = @Id";
        await using var conn = OpenConnection();

        var product = await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id });

        if (product == null)
            return new Product();

        return product;
    }

    public void UpdateProduct(Product product)
    {
        var sql =
            @"UPDATE product SET name= @Name, deleted_date = @DeletedDate, updated_date = @UptadedDate, created_date = @CreatedDate, is_deleted = @IsDeleted  WHERE id = @Id";
        using var conn = OpenConnection();
        conn.ExecuteAsync(sql, product);
    }
}