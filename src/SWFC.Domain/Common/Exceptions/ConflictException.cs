namespace SWFC.Domain.Common.Exceptions;

public sealed class ConflictException : SwfcException
{
    public ConflictException(string code, string message)
        : base(code, message)
    {
    }

    public ConflictException(string code, string message, Exception innerException)
        : base(code, message, innerException)
    {
    }
}
