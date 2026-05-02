using System.Linq.Expressions;

namespace WebApp.Interfaces;

public interface IBackgroundJobService
{
	void Schedule<T>(Expression<Func<T, Task>> expression);
}