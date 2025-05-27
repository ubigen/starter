using System.Reflection;
using Starter.Api.Capabilities.Pipeline;
using Starter.Api.Capabilities.Validator;

namespace Starter.Api.Capabilities.Command;

public static class CommandExtension
{
    public static IServiceCollection AddCommand(this IServiceCollection services, Assembly assembly)
    {
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
        
        services.AddScoped<ICommandBus, CommandBus>();

        return services;
    }
}