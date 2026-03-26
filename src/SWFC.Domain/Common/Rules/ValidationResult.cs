namespace SWFC.Domain.Common.Validation;

public sealed class ValidationResult
{
    private readonly List<ValidationError> _errors = new();

    public bool IsValid => _errors.Count == 0;

    public IReadOnlyCollection<ValidationError> Errors => _errors.AsReadOnly();

    public void Add(string code, string field, string message)
    {
        _errors.Add(new ValidationError(code, field, message));
    }

    public void Add(ValidationError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        _errors.Add(error);
    }

    public void AddRange(IEnumerable<ValidationError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        _errors.AddRange(errors);
    }

    public static ValidationResult Success() => new();
}
