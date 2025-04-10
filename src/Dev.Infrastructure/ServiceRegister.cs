using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Dev.Infrastructure;

public static class ServiceRegister
{
    public static IServiceCollection AddInfrastructureservices(this IServiceCollection services, IConfiguration configuration)
    {
        AddConnection(services, configuration);

        return services;
    }

    private static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<AppContext>(options => options.UseNpgsql(configuration["PostgreSQL:ConnectionString"]));

        return services;
    }
}