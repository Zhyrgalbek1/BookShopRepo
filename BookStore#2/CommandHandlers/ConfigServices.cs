using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommandHandlers;

public static class ConfigServices
{
    public static IServiceCollection AddCommandHandler(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()));
        return services;
    }
}
