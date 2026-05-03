using ApplicationServices.Interfaces;

namespace ApplicationService.Implementation;

public class SecurityService : ISecurityService
{
	public bool IsCurrentUserAdmin { get; }
	public string[] CurrentUserPermissions { get; }
}