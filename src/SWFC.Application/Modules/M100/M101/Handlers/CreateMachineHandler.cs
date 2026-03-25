
using SWFC.Application.Common.Validation;
using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Domain.Common.Errors;
using SWFC.Domain.Common.Exceptions;
using SWFC.Domain.Common.Results;

using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Domain.Common.Results;
using SWFC.Domain.Common.Errors;

using SWFC.Domain.Common.Security;
using SWFC.Domain.Modules.M100.M101.Entities;
using SWFC.Domain.Modules.M100.M101.ValueObjects;

namespace SWFC.Application.Modules.M100.M101.Handlers;

public sealed class CreateMachineHandler
{

    private readonly ICommandValidator<CreateMachineCommand> _validator;

    public CreateMachineHandler(ICommandValidator<CreateMachineCommand> validator)
    {
        _validator = validator;
    }

    public Result<Machine> Handle(CreateMachineCommand command)
    {
        var validation = _validator.Validate(command);

        if (!validation.IsValid)
        {
            return Result<Machine>.Failure(
                new Error("VALIDATION_FAILED", "Validation failed.", ErrorCategory.Validation));
        }


    public Result<Machine> Handle(CreateMachineCommand command)
    {

        try
        {
            var name = MachineName.Create(command.Name);

            var context = ChangeContext.Create(
                command.ActorId,
                DateTimeOffset.UtcNow,
                command.Reason);

            var machine = Machine.Create(
                command.Id,
                name,
                context);

            return Result<Machine>.Success(machine);
        }

        catch (ValidationException ex)
        {
            return Result<Machine>.Failure(
                new Error(ex.Code, ex.Message, ErrorCategory.Validation));
        }
        catch (DomainException ex)
        {
            return Result<Machine>.Failure(
                new Error(ex.Code, ex.Message, ErrorCategory.Domain));
        }
        catch (SecurityException ex)
        {
            return Result<Machine>.Failure(
                new Error(ex.Code, ex.Message, ErrorCategory.Security));
        }
        catch (Exception)
        {
            return Result<Machine>.Failure(
                new Error("APP_UNEXPECTED_ERROR", "An unexpected error occurred.", ErrorCategory.Technical));
        }
    }
}

        catch (Exception ex)
        {
            return Result<Machine>.Failure(
                new Error("APP_ERROR", ex.Message, ErrorCategory.Technical));
        }
    }
}


