namespace SWFC.Application.Security.Authorization;

public sealed class AuthorizationResult
{
    public bool IsAllowed { get; }
    public string? Reason { get; }

    private AuthorizationResult(bool isAllowed, string? reason)
    {
        IsAllowed = isAllowed;
        Reason = reason;
    }

    public static AuthorizationResult Allow() => new(true, null);

    public static AuthorizationResult Deny(string reason) => new(false, reason);
}
