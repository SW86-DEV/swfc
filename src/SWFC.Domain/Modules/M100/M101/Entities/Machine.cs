using SWFC.Domain.Common.Exceptions;
using SWFC.Domain.Common.Security;
using SWFC.Domain.Common.Validation;
using SWFC.Domain.Modules.M100.M101.ValueObjects;

namespace SWFC.Domain.Modules.M100.M101.Entities;

public sealed class Machine
{
    public Guid Id { get; }
    public MachineName Name { get; private set; }
    public AuditInfo LastChange { get; private set; }

    private Machine(Guid id, MachineName name, AuditInfo audit)
    {
        Id = id;
        Name = name;
        LastChange = audit;
    }

    public static Machine Create(Guid id, MachineName name, ChangeContext context)
    {
        Guard.AgainstDefault(id, nameof(id), "MACHINE_ID_REQUIRED");
        Guard.AgainstNull(context, nameof(context), "SEC_CONTEXT_REQUIRED");

        var audit = AuditInfo.From(context);

        return new Machine(id, name, audit);
    }

    public void Rename(MachineName newName, ChangeContext context)
    {
        Guard.AgainstNull(context, nameof(context), "SEC_CONTEXT_REQUIRED");

        if (newName.Value == Name.Value)
            throw new DomainException("MACHINE_NAME_UNCHANGED", "Machine name is already set to this value.");

        Name = newName;
        LastChange = AuditInfo.From(context);
    }
}
