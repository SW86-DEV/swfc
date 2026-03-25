namespace SWFC.Domain.Common.Security;

public sealed record AuditInfo(
    string ChangedBy,
    DateTimeOffset ChangedAt,
    string Reason)
{
    public static AuditInfo From(ChangeContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return new AuditInfo(
            context.ActorId,
            context.OccurredAt,
            context.Reason);
    }
}
