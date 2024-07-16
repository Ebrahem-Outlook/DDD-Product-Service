using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Core.Abstractions.Data;
using Products.Domain.Products;
using Products.Infrastructure.Caching;
using Products.Infrastructure.Database;
using Products.Infrastructure.Repositories;

namespace Products.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        string? ConnectionString = configuration.GetConnectionString("Local-SqlServer");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());


        services.AddMemoryCache();

        services.AddScoped<ProductRepository>();

        services.AddScoped<IProductRepository>(serviceProvider =>
        {
            var decorated = serviceProvider.GetRequiredService<ProductRepository>();
            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();

            return new CachedProductRepository(decorated, memoryCache);
        });

        return services;
    }
}
