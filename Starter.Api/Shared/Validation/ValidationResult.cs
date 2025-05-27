
namespace Starter.Api.Shared.Validation;

public record ValidationResult
{
    private readonly Dictionary<string, ValidationFailure> _errorsByProperty = new();
    public IEnumerable<ValidationFailure> Errors => _errorsByProperty.Values;

    public bool IsValid => _errorsByProperty.Count == 0;

    public void AddError(string property, string message)
    {
        if (!_errorsByProperty.TryGetValue(property, out var validationFailure))
        {
            validationFailure = new ValidationFailure(property, new List<string>());
            _errorsByProperty[property] = validationFailure;
        }

        validationFailure.Messages.Add(message);
    }

    public void AddError(string property, IEnumerable<string> messages)
    {
        if (!_errorsByProperty.TryGetValue(property, out var validationFailure))
        {
            validationFailure = new ValidationFailure(property, new List<string>());
            _errorsByProperty[property] = validationFailure;
        }

        validationFailure.Messages.AddRange(messages);
    }

    public void Merge(ValidationResult other)
    {
        foreach (var failure in other.Errors)
        {
            AddError(failure.Property, failure.Messages);
        }
    }

    public record ValidationFailure(string Property, List<string> Messages);
}
