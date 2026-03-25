using SWFC.Domain.Common.Validation;

namespace SWFC.Domain.Common.Exceptions;

public sealed class ValidationException : SwfcException
{
    public IReadOnlyCollection<ValidationError> Errors { get; }

    public ValidationException(string code, string message)
        : base(code, message)
    {
        Errors = Array.Empty<ValidationError>();
    }

    public ValidationException(string code, string message, IReadOnlyCollection<ValidationError> errors)
        : base(code, message)
    {
        Errors = errors ?? Array.Empty<ValidationError>();
    }

    public ValidationException(string code, string message, Exception innerException)
        : base(code, message, innerException)
    {
        Errors = Array.Empty<ValidationError>();
    }
}
