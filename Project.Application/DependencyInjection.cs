using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Profiles;
using Project.Repository.UnitOfWorks;
using Project.SQL.Server.UnitOfWorks;
using System.Reflection;

namespace Project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
        services.AddAutoMapper(typeof(MyMapper).Assembly);

        return services;
    }
}
