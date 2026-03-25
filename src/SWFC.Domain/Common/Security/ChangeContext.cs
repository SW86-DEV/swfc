namespace SWFC.Domain.Common.Security;

public sealed record ChangeContext(
    string ActorId,
    DateTimeOffset OccurredAt,
    string Reason)
{
    public static ChangeContext Create(string actorId, DateTimeOffset occurredAt, string reason)
    {
        if (string.IsNullOrWhiteSpace(actorId))
            throw new ArgumentException("ActorId must not be empty.", nameof(actorId));

        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Reason must not be empty.", nameof(reason));

        return new ChangeContext(actorId, occurredAt, reason);
    }
}
