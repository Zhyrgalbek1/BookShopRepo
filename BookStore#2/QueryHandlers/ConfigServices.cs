using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace QueryHandlers;

public static class ConfigServices
{
    public static IServiceCollection AddQueryHandler(this 
        IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()));
        return services;
    }
}
