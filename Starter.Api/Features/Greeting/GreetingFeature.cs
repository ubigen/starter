using Starter.Api.Capabilities.Command;
using Starter.Api.Capabilities.Endpoint;
using Starter.Api.Capabilities.Feature;
using Starter.Api.Capabilities.Query;
using Starter.Api.Capabilities.Validator;

namespace Starter.Api.Features.Greeting;

internal sealed class GreetingFeature : IFeatureModule
{
    public void Add(IServiceCollection services)
    {
        var assembly = typeof(GreetingFeature).Assembly;

        services.AddCommand(assembly);
        services.AddValidators(assembly);
        services.AddEndpoints(assembly);
        services.AddQuery(assembly);
    }

    public void Map(WebApplication app)
    {
        app.MapGroup("/greetings").MapEndpoints();
    }
}