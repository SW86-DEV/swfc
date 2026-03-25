using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Application.Modules.M100.M101.Policies;
using SWFC.Application.Security;
using SWFC.Application.Security.Authorization;
using SWFC.Domain.Common.Exceptions;

namespace SWFC.Application.Tests.Modules.M100.M101.Policies;

public sealed class CreateMachinePolicyTests
{
    [Fact]
    public async Task AuthorizeAsync_Should_Throw_When_User_Is_Not_Authenticated()
    {
        var policy = new CreateMachinePolicy();
        var context = new SecurityContext(
            string.Empty,
            false,
            Array.Empty<string>());

        var command = new CreateMachineCommand(
            Guid.NewGuid(),
            "Machine-01",
            "Create machine");

        await Assert.ThrowsAsync<SecurityException>(() =>
            policy.AuthorizeAsync(context, command, CancellationToken.None));
    }

    [Fact]
    public async Task AuthorizeAsync_Should_Throw_When_Claim_Is_Missing()
    {
        var policy = new CreateMachinePolicy();
        var context = new SecurityContext(
            "user-1",
            true,
            Array.Empty<string>());

        var command = new CreateMachineCommand(
            Guid.NewGuid(),
            "Machine-01",
            "Create machine");

        await Assert.ThrowsAsync<SecurityException>(() =>
            policy.AuthorizeAsync(context, command, CancellationToken.None));
    }

    [Fact]
    public async Task AuthorizeAsync_Should_Pass_When_Claim_Exists()
    {
        var policy = new CreateMachinePolicy();
        var context = new SecurityContext(
            "user-1",
            true,
            new[] { AuthorizationRequirement.MachineCreate });

        var command = new CreateMachineCommand(
            Guid.NewGuid(),
            "Machine-01",
            "Create machine");

        await policy.AuthorizeAsync(context, command, CancellationToken.None);
    }
}
