using SWFC.Application.Common.Validation;
using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Application.Security;
using SWFC.Domain.Common.Results;
using SWFC.Domain.Common.Security;
using SWFC.Domain.Modules.M100.M101.Entities;
using SWFC.Domain.Modules.M100.M101.ValueObjects;

namespace SWFC.Application.Modules.M100.M101.Handlers;

public sealed class CreateMachineHandler
    : ValidatedHandler<CreateMachineCommand, Machine>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IAuthorizationPolicy<CreateMachineCommand> _authorizationPolicy;

    public CreateMachineHandler(
        ICommandValidator<CreateMachineCommand> validator,
        ICurrentUserService currentUserService,
        IAuthorizationPolicy<CreateMachineCommand> authorizationPolicy)
        : base(validator)
    {
        _currentUserService = currentUserService;
        _authorizationPolicy = authorizationPolicy;
    }

    protected override async Task<Result<Machine>> ExecuteAsync(
        CreateMachineCommand command,
        CancellationToken cancellationToken)
    {
        var securityContext = _currentUserService.GetCurrent();

        await _authorizationPolicy.AuthorizeAsync(
            securityContext,
            command,
            cancellationToken);

        var name = MachineName.Create(command.Name);

        var context = ChangeContext.Create(
            securityContext.UserId,
            DateTimeOffset.UtcNow,
            command.Reason);

        var machine = Machine.Create(
            command.Id,
            name,
            context);

        return Result<Machine>.Success(machine);
    }
}
