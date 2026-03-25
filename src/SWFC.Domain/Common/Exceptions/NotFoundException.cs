namespace SWFC.Domain.Common.Exceptions;

public sealed class NotFoundException : SwfcException
{
    public NotFoundException(string code, string message)
        : base(code, message)
    {
    }

    public NotFoundException(string code, string message, Exception innerException)
        : base(code, message, innerException)
    {
    }
}
