using Infrastructure.Shared;
using Domain.Repos;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.DataBase;
using Infrastructure.Repos;
using Infrastructure.Repositories;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture;

public static class ConfigServices
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUserRepo, UserRepo>();
        services.AddTransient<IBookRepo,BookRepo>();
        services.AddTransient<IBasketRepo,BasketRepository>();

        return services;
    }
}
