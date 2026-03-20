using CleanArchitecture.Application;

namespace CleanArchitecture.WebApi;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await next(httpContext);
		}
		catch (EntityNotFoundException ex)
		{
			httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
		}
	}
}