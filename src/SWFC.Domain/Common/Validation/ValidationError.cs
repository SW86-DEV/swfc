namespace SWFC.Domain.Common.Validation;

public sealed record ValidationError(
    string Code,
    string Field,
    string Message);
