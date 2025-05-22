using System.Reflection;

namespace Starter.Api.Extensions.Command;

public static class CommandExtension
{
    public static IServiceCollection AddCommand(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var handlerTypes = assembly
            .DefinedTypes
            .Where(type => type.IsClass 
                           && !type.IsAbstract 
                           && type.GetInterfaces()
                               .Any(i => i.IsGenericType 
                                         && i.GetGenericTypeDefinition() == typeof(ICommand<,>)));
        
        foreach (var handlerType in handlerTypes)
        {
            var interfaces = handlerType
                .GetInterfaces()
                .Where(i => i.IsGenericType 
                            && i.GetGenericTypeDefinition() == typeof(ICommand<,>));
            
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, handlerType);
            }
        }
        
        return services;
    }
}