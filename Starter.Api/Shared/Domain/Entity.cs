
namespace Starter.Api.Shared.Domain;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public void MarkAsUpdated() 
        => UpdatedAt = DateTimeOffset.UtcNow;
}