namespace SWFC.Application.Security;

public interface ICurrentUserService
{
    SecurityContext GetCurrent();
}
