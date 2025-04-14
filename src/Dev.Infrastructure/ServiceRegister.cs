using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Dev.Domain.Abstraction;
using Dev.Infrastructure.Repositories;
using Dev.Infrastructure.UnitOfWorks;

namespace Dev.Infrastructure;

public static class ServiceRegister
{
    public static IServiceCollection AddInfrastructureservices(this IServiceCollection services, IConfiguration configuration)
    {
        AddConnection(services, configuration);

        AddRepositories(services);

        return services;
    }

    private static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<AppContext>(options => options.UseNpgsql(configuration["PostgreSQL:ConnectionString"]));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}