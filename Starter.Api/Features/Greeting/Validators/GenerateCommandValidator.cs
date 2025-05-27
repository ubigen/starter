using Starter.Api.Capabilities.Validator;
using Starter.Api.Features.Greeting.Commands.Generate;
using Starter.Api.Shared.Validation;

namespace Starter.Api.Features.Greeting.Validators;

internal sealed class GenerateCommandValidator(ValidationResult vr) : IValidator<GenerateGreetingCommand>
{
    public ValidationResult Validate(GenerateGreetingCommand cmd)
    {
        
        if (string.IsNullOrWhiteSpace(cmd.Name) || cmd.Name.Trim().Length < 3 || cmd.Name.Trim().Length > 20)
        {
            vr.AddError(nameof(cmd.Name), "İsim 3 ile 20 karakter arasında olmalıdır.");
        }

        return vr;
    }
}