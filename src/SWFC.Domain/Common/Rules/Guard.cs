using SWFC.Domain.Common.Exceptions;

namespace SWFC.Domain.Common.Validation;

public static class Guard
{
    public static void AgainstNull(object? value, string fieldName, string code)
    {
        if (value is null)
            throw new ValidationException(code, $"{fieldName} must not be null.");
    }

    public static void AgainstNullOrWhiteSpace(string? value, string fieldName, string code)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException(code, $"{fieldName} must not be empty.");
    }

    public static void AgainstMaxLength(string? value, int maxLength, string fieldName, string code)
    {
        if (value is not null && value.Length > maxLength)
            throw new ValidationException(code, $"{fieldName} must not exceed {maxLength} characters.");
    }

    public static void AgainstMinLength(string? value, int minLength, string fieldName, string code)
    {
        if (value is not null && value.Length < minLength)
            throw new ValidationException(code, $"{fieldName} must be at least {minLength} characters long.");
    }

    public static void AgainstDefault<T>(T value, string fieldName, string code)
        where T : struct
    {
        if (EqualityComparer<T>.Default.Equals(value, default))
            throw new ValidationException(code, $"{fieldName} must not be default.");
    }

    public static void Against(bool condition, string code, string message)
    {
        if (condition)
            throw new ValidationException(code, message);
    }
}
