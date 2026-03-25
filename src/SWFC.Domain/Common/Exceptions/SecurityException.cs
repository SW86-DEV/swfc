namespace SWFC.Domain.Common.Exceptions;

public sealed class SecurityException : SwfcException
{
    public SecurityException(string code, string message)
        : base(code, message)
    {
    }

    public SecurityException(string code, string message, Exception innerException)
        : base(code, message, innerException)
    {
    }
}
