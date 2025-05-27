using System.Reflection;

namespace Starter.Api.Capabilities.Query;

public static class QueryExtension
{
    public static IServiceCollection AddQuery(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly
            .DefinedTypes
            .Where(type => type.IsClass 
                           && !type.IsAbstract 
                           && type.GetInterfaces()
                               .Any(i => i.IsGenericType 
                                         && i.GetGenericTypeDefinition() == typeof(IQuery<,>)));
        
        foreach (var handlerType in handlerTypes)
        {
            var interfaces = handlerType
                .GetInterfaces()
                .Where(i => i.IsGenericType 
                            && i.GetGenericTypeDefinition() == typeof(IQuery<,>));
            
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, handlerType);
            }
        }
        
        return services;
    }
}