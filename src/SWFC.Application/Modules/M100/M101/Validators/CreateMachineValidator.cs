using SWFC.Application.Common.Validation;
using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Domain.Common.Errors;
using SWFC.Domain.Common.Validation;

namespace SWFC.Application.Modules.M100.M101.Validators;

public sealed class CreateMachineValidator : ICommandValidator<CreateMachineCommand>
{
    public ValidationResult Validate(CreateMachineCommand command)
    {
        var result = new ValidationResult();

        if (command.Id == Guid.Empty)
            result.Add(ErrorCodes.Machine.IdRequired, nameof(command.Id), "Id must not be empty.");

        if (string.IsNullOrWhiteSpace(command.Name))
            result.Add(ErrorCodes.Machine.NameRequired, nameof(command.Name), "Name is required.");

        if (string.IsNullOrWhiteSpace(command.ActorId))
            result.Add(ErrorCodes.General.ContextRequired, nameof(command.ActorId), "ActorId is required.");

        if (string.IsNullOrWhiteSpace(command.Reason))
            result.Add("MACHINE_REASON_REQUIRED", nameof(command.Reason), "Reason is required.");

        return result;
    }
}
