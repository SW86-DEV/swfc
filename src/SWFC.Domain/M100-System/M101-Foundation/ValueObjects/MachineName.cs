using SWFC.Domain.Common.Errors;
using SWFC.Domain.Common.Validation;
using SWFC.Domain.Common.Errors;

namespace SWFC.Domain.Modules.M100.M101.ValueObjects;

public sealed class MachineName
{
    public string Value { get; }

    private MachineName(string value)
    {
        Value = value;
    }

    public static MachineName Create(string value)
    {
        

        Guard.AgainstNullOrWhiteSpace(value, nameof(MachineName), ErrorCodes.Machine.NameRequired);
        Guard.AgainstMaxLength(value, 100, nameof(MachineName), ErrorCodes.Machine.NameTooLong);

        return new MachineName(value);
    }

    public override string ToString() => Value;
}
