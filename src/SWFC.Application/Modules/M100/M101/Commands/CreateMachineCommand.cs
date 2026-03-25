namespace SWFC.Application.Modules.M100.M101.Commands;

public sealed record CreateMachineCommand(
    Guid Id,
    string Name,
    string ActorId,
    string Reason);
