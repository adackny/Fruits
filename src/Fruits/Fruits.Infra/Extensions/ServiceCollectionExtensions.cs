using Fruits.Application;
using Fruits.Domain;
using Fruits.Domain.Repositories;
using Fruits.Infra.Contexts;
using Fruits.Infra.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fruits.Infra;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraLayer(this IServiceCollection services, string connString)
    {
        services.AddHttpClient<ITradingFruitsService, TradingFruitsService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5109");
        });

        services.AddDbContext<FruitsDbContext>(optionsBuilder =>
            optionsBuilder.UseSqlite(connString));

        services.AddScoped<IFruitsUnitOfWork, FruitsUnitOfWork>();
        services.AddScoped<IFruitsRepository, FruitsRepository>();

        return services;
    }
}
