namespace Project.SQL.Server.Infrastructure;

public abstract class BaseSqlRepository
{
    private readonly string _connectionString;

    internal BaseSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
}
