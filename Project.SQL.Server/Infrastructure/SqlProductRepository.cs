using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Project.Domain.Entities;
using Project.Repository.Repositories.ProductRepositories;
using Project.SQL.Server.DbContexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        
        var sql = @"INSERT INTO product(name,description,created_date,deleted_date,updated_date,is_deleted) 
                   VALUES (@Name,@Descp,@Createddate,@DeletedDate,@UpdateDate,@IsDeleted)";
        using var conn = OpenConnection();
        await conn.ExecuteScalarAsync(sql,entity);

       
    }


    public void DeleteProudct(int id)
    {
        var checkSql = "SELECT id from product WHERE id = @Id AND is_deleted=0";
        var sql = "UPDATE product" +
            "SET is_deleted = 1," +
            "    deleted_date = GETDATE()" +
            "WHERE id = @Id";
        using var conn = OpenConnection();
        var countId =  conn.ExecuteScalar<int>(checkSql,new { id});
        if (countId > 0)
        {
            conn.ExecuteAsync(sql, new { id });
        }
        
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var sql = "SELECT * FROM vw_product";
        using var conn = OpenConnection();
        var data =  conn.Query<Product>(sql);
        return data;
    }

    public async Task<Product> GetById(int id)
    {
        var sql = "SELECT * FROM product WHERE id = @Id";
        using var conn = OpenConnection();
        return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id });
    }

    public void UpdateProduct(Product product)
    {
        var sql = @"UPDATE product SET name= @Name, deleted_date = @DeletedDate, updated_date = @UptadedDate, created_date = @CreatedDate, is_deleted = @IsDeleted  WHERE id = @Id";
        using var conn = OpenConnection();
        conn.ExecuteAsync(sql, product);
    }
}
