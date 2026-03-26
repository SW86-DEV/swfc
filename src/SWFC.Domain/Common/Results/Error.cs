namespace SWFC.Domain.Common.Errors;

public sealed record Error(
    string Code,
    string Message,
    ErrorCategory Category)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorCategory.Technical);
}
