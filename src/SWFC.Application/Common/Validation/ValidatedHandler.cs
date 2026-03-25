using SWFC.Domain.Common.Errors;
using SWFC.Domain.Common.Exceptions;
using SWFC.Domain.Common.Results;

namespace SWFC.Application.Common.Validation;

public abstract class ValidatedHandler<TCommand, TResult>
{
    private readonly ICommandValidator<TCommand> _validator;

    protected ValidatedHandler(ICommandValidator<TCommand> validator)
    {
        _validator = validator;
    }

    public async Task<Result<TResult>> HandleAsync(
        TCommand command,
        CancellationToken cancellationToken = default)
    {
        var validation = _validator.Validate(command);

        if (!validation.IsValid)
        {
            return Result<TResult>.Failure(
                new Error(
                    ErrorCodes.Validation.Failed,
                    "Validation failed.",
                    ErrorCategory.Validation));
        }

        try
        {
            return await ExecuteAsync(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            return Result<TResult>.Failure(
                new Error(ex.Code, ex.Message, ErrorCategory.Validation));
        }
        catch (DomainException ex)
        {
            return Result<TResult>.Failure(
                new Error(ex.Code, ex.Message, ErrorCategory.Domain));
        }
        catch (SecurityException ex)
        {
            return Result<TResult>.Failure(
                new Error(ex.Code, ex.Message, ErrorCategory.Security));
        }
        catch (Exception)
        {
            return Result<TResult>.Failure(
                new Error("APP_UNEXPECTED_ERROR", "An unexpected error occurred.", ErrorCategory.Technical));
        }
    }

    protected abstract Task<Result<TResult>> ExecuteAsync(
        TCommand command,
        CancellationToken cancellationToken);
}
