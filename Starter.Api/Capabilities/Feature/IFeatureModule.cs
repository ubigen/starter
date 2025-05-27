namespace Starter.Api.Capabilities.Feature;

public interface IFeatureModule
{
    void Add(IServiceCollection services);
    void Map(WebApplication app);
}