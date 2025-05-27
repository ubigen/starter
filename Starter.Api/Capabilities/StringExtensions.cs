namespace Starter.Api.Capabilities;

public static class StringExtensions
{
    public static string? ToTrim(this string? input) 
        => string.IsNullOrWhiteSpace(input) 
        ? null 
        : input.Trim();
    
    public static string? ToUnique(this string? input) 
        => input?
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    
    public static string? ToUpperCase(this string? input) 
        => ToTrim(input)?.ToUpperInvariant();

    public static string? ToLowerCase(this string? input)
        => ToTrim(input)?.ToLowerInvariant();

    public static string? CapitalizeFirstLetter(this string? input)
    {
        var normalizedInput = ToTrim(input);

        return string.IsNullOrEmpty(normalizedInput)
            ? normalizedInput
            : char.ToUpperInvariant(normalizedInput[0]) + normalizedInput.Substring(1).ToLowerInvariant();
    }

    public static string? CapitalizeEachWord(this string? input)
    {
        var normalizedInput = ToTrim(input);

        return string.IsNullOrEmpty(normalizedInput)
            ? normalizedInput
            : string.Join(' ', normalizedInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.CapitalizeFirstLetter()));
    }
    
    public static string? MaskAfter(this string? input, int unmaskedCount = 4)
    {
        var trimmed = ToTrim(input);
        if (string.IsNullOrEmpty(trimmed))
            return trimmed;
        
        if (trimmed.Length <= unmaskedCount)
            return trimmed;
        
        var firstPart = trimmed.Substring(0, unmaskedCount);
        var maskedPart = new string('*', trimmed.Length - unmaskedCount);
        return $"{firstPart}{maskedPart}";
    }
}