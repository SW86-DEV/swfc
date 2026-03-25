using SWFC.Domain.Common.Errors;

namespace SWFC.Domain.Common.Results;

public sealed class Result<T> : Result
{
    private readonly T? _value;

    private Result(T value)
        : base(true, Error.None)
    {
        _value = value;
    }

    private Result(Error error)
        : base(false, error)
    {
        _value = default;
    }

    public T Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Failed result does not contain a value.");

    public static Result<T> Success(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        return new Result<T>(value);
    }

    public static new Result<T> Failure(Error error) => new(error);
}
