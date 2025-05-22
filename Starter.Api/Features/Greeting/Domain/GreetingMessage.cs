using Starter.Api.Shared.Domain;

namespace Starter.Api.Features.Greeting.Domain;

internal sealed class GreetingMessage : Entity, IAggregateRoot
{
    public string Text { get; }

    private GreetingMessage(string text)
    {
        Text = text;
    }

    public static GreetingMessage Create(string name)
    {
        var current = DateTime.Now;
        var prefix = GetGreetingPrefix(current);
        return new GreetingMessage($"{prefix}, {name}!");
    }

    private static string GetGreetingPrefix(DateTime time)
    {
        var hour = time.Hour;

        return hour switch
        {
            >= 5 and < 12  => "Günaydın",
            >= 12 and < 17 => "İyi günler",
            >= 17 and < 22 => "İyi akşamlar",
            _              => "İyi geceler"
        };
    }

    public override string ToString() => Text;
}