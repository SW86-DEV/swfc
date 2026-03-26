namespace SWFC.Application.Security;

public sealed class DefaultCurrentUserService : ICurrentUserService
{
    public SecurityContext GetCurrent()
    {
        return new SecurityContext(
            string.Empty,
            false,
            Array.Empty<string>());
    }
}
