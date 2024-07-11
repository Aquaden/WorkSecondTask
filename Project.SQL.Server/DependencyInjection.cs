using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Repository.UnitOfWorks;
using Project.SQL.Server.DbContexts;
using Project.SQL.Server.UnitOfWorks;

namespace Project.SQL.Server;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services,string connectionString)
    {

       services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

        return services;
    }
}
