using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Starter.Api.Capabilities.Endpoint;

public static class EndpointExtension
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type =>
                type is { IsAbstract: false, IsInterface: false } &&
                typeof(IEndpoint).IsAssignableFrom(type))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);
        return services;
    }

    public static void MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder =
            routeGroupBuilder is not null
                ? routeGroupBuilder
                : app;

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }
    }

    public static void MapEndpoints(this RouteGroupBuilder group)
    {
        var serviceProvider = ((IEndpointRouteBuilder)group).ServiceProvider;
        var endpoints = serviceProvider.GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(group);
        }
    }
}