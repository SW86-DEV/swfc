namespace SWFC.Application.Security;

public interface IAuthorizationPolicy<in TRequest>
{
    Task AuthorizeAsync(
        SecurityContext context,
        TRequest request,
        CancellationToken cancellationToken);
}
