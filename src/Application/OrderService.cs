using AutoMapper;
using CleanArchitecture.Application;
using DomainServices.Interfaces;
using Infrastructure.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class OrderService(IDbContext dbContext, IMapper mapper, IOrderDomainService orderDomainService) : IOrderService
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
		dto.Total = orderDomainService.GetTotal(order);
		return dto;
	}
}