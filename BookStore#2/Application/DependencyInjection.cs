using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using CommandHandlers.Users.Create;
using QueryHandlers.Books.GetAll;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(
                Assembly.GetAssembly(typeof(CreateUserHandler))!);

            config.RegisterServicesFromAssembly(
             Assembly.GetAssembly(typeof(GetByTitleHandler))!);
        });

        return services;
    }
}
