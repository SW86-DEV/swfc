using SWFC.Domain.Common.Results;
using SWFC.Domain.Common.Errors;
using SWFC.Domain.Common.Security;
using SWFC.Domain.Modules.M100.M101.Entities;
using SWFC.Domain.Modules.M100.M101.ValueObjects;

namespace SWFC.Application.Modules.M100.M101.Handlers;

public sealed class CreateMachineHandler
{
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
        catch (Exception ex)
        {
            return Result<Machine>.Failure(
                new Error("APP_ERROR", ex.Message, ErrorCategory.Technical));
        }
    }
}
