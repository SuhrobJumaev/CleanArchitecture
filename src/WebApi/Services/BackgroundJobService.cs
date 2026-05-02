using System.Linq.Expressions;
using Hangfire;
using WebApp.Interfaces;

namespace WebApi.Services;

public class BackgroundJobService : IBackgroundJobService
{
	public void Schedule<T>(Expression<Func<T, Task>> expression)
	{
		BackgroundJob.Schedule(expression, TimeSpan.Zero);
	}
}