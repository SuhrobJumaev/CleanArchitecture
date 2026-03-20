using AutoMapper;
using CleanArchitecture.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Application;

public class OrderService(AppDbContext dbContext, IMapper mapper) : IOrderService
{
	

	public async Task<OrderDto> GetOrderByIdAsync(int id)
	{
		Console.WriteLine("Hello World!");
		var order = await dbContext.Orders
		                           .AsNoTracking()
		                           .Include(x => x.Items).ThenInclude(x => x.Product)
		                           .FirstOrDefaultAsync(x => x.Id == id);

		if (order == null) throw new EntityNotFoundException();
		
		var dto = mapper.Map<OrderDto>(order);
		dto.Total = order.GetTotal();
		return dto;
	}
}