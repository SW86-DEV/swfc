namespace SWFC.Domain.Common.Exceptions;

public abstract class SwfcException : Exception
{
    public string Code { get; }

    protected SwfcException(string code, string message)
        : base(message)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Exception code must not be empty.", nameof(code));

        Code = code;
    }

    protected SwfcException(string code, string message, Exception innerException)
        : base(message, innerException)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Exception code must not be empty.", nameof(code));

        Code = code;
    }
}
