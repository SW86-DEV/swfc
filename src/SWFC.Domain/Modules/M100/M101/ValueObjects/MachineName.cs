using SWFC.Domain.Common.Validation;

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
        Guard.AgainstNullOrWhiteSpace(value, nameof(MachineName), "MACHINE_NAME_REQUIRED");
        Guard.AgainstMaxLength(value, 100, nameof(MachineName), "MACHINE_NAME_TOO_LONG");

        return new MachineName(value);
    }

    public override string ToString() => Value;
}
