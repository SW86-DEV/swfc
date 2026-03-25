using SWFC.Application.Common.Validation;
using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Domain.Common.Results;
using SWFC.Domain.Common.Security;
using SWFC.Domain.Modules.M100.M101.Entities;
using SWFC.Domain.Modules.M100.M101.ValueObjects;

namespace SWFC.Application.Modules.M100.M101.Handlers;

public sealed class CreateMachineHandler
    : ValidatedHandler<CreateMachineCommand, Machine>
{
    public CreateMachineHandler(ICommandValidator<CreateMachineCommand> validator)
        : base(validator)
    {
    }

    protected override Result<Machine> Execute(CreateMachineCommand command)
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
}
