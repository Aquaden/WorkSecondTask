
using Npgsql;

namespace Project.SQL.Server.Infrastructure;

public abstract class BaseSqlRepository
{
    private readonly string _connectionString;

    internal BaseSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    protected NpgsqlConnection OpenConnection()
    {
        var con = new NpgsqlConnection(_connectionString);
        con.Open();
        return con;
    }
}
