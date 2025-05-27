namespace Starter.Api.Capabilities.Feature;

public static class FeatureModuleExtensions
{
    public static IServiceCollection AddFeature<TFeature>(this IServiceCollection services)
        where TFeature : IFeatureModule, new()
    {
        new TFeature().Add(services);
        return services;
    }

    public static WebApplication UseFeature<TFeature>(this WebApplication app)
        where TFeature : IFeatureModule, new()
    {
        new TFeature().Map(app);
        return app;
    }
}