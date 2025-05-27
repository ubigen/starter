using Microsoft.Extensions.DependencyInjection.Extensions;
using Starter.Api.Capabilities.Validator;

namespace Starter.Api.Capabilities.Pipeline;

public static class PipelineExtensions
{
    public static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)),
        });

        return services;
    }
}