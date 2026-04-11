using WebApp.Interfaces;

namespace WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
	public string Email => "test@gmail.com";
}