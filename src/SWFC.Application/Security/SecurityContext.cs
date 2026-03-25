namespace SWFC.Application.Security;

public sealed class SecurityContext
{
    public string UserId { get; }
    public bool IsAuthenticated { get; }
    public IReadOnlyCollection<string> Claims { get; }

    public SecurityContext(
        string userId,
        bool isAuthenticated,
        IReadOnlyCollection<string> claims)
    {
        UserId = userId;
        IsAuthenticated = isAuthenticated;
        Claims = claims ?? Array.Empty<string>();
    }

    public bool HasClaim(string claim)
    {
        return Claims.Contains(claim, StringComparer.OrdinalIgnoreCase);
    }
}
