namespace SWFC.Domain.Common.Errors;

public static class ErrorCodes
{
    public static class General
    {
        public const string ContextRequired = "SEC_CONTEXT_REQUIRED";
    }

    public static class Machine
    {
        public const string NameRequired = "MACHINE_NAME_REQUIRED";
        public const string NameTooLong = "MACHINE_NAME_TOO_LONG";
        public const string NameUnchanged = "MACHINE_NAME_UNCHANGED";
        public const string IdRequired = "MACHINE_ID_REQUIRED";
    }

    public static class Validation
    {
        public const string Failed = "VALIDATION_FAILED";
    }
}
