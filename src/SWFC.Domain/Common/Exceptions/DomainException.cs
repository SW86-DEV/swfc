namespace SWFC.Domain.Common.Exceptions;

public sealed class DomainException : SwfcException
{
    public DomainException(string code, string message)
        : base(code, message)
    {
    }

    public DomainException(string code, string message, Exception innerException)
        : base(code, message, innerException)
    {
    }
}
