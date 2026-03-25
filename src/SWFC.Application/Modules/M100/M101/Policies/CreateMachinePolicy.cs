using SWFC.Application.Security;
using SWFC.Application.Security.Authorization;
using SWFC.Domain.Common.Errors;
using SWFC.Domain.Common.Exceptions;
using SWFC.Application.Modules.M100.M101.Commands;

namespace SWFC.Application.Modules.M100.M101.Policies;

public sealed class CreateMachinePolicy : IAuthorizationPolicy<CreateMachineCommand>
{
    public Task AuthorizeAsync(
        SecurityContext context,
        CreateMachineCommand request,
        CancellationToken cancellationToken)
    {
        if (context is null)
        {
            throw new SecurityException(
                ErrorCodes.Security.NotAuthenticated,
                "Security context is missing.");
        }

        if (!context.IsAuthenticated)
        {
            throw new SecurityException(
                ErrorCodes.Security.NotAuthenticated,
                "User is not authenticated.");
        }

        if (!context.HasClaim(AuthorizationRequirement.MachineCreate))
        {
            throw new SecurityException(
                ErrorCodes.Security.NotAuthenticated,
                "Missing permission: machine:create.");
        }

        return Task.CompletedTask;
    }
}
