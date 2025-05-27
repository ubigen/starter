using System.Reflection;
using Starter.Api.Shared.Validation;

namespace Starter.Api.Capabilities.Validator;

public static class ValidatorExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services, Assembly assembly)
    {
        var validatorTypes = assembly
            .DefinedTypes
            .Where(type =>
                type.IsClass &&
                !type.IsAbstract &&
                type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IValidator<>)));

        foreach (var validatorType in validatorTypes)
        {
            var interfaces = validatorType
                .GetInterfaces()
                .Where(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IValidator<>));

            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, validatorType);
            }
        }

        services.AddScoped<ValidationResult>();

        return services;
    }
}