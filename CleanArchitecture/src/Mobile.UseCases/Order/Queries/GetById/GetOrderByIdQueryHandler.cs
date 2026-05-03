using AutoMapper;
using DataAccess.Interfaces;
using Delivery.Interfaces;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mobile.UseCases.Order.Queries.GetById;

public class GetOrderByIdQueryHandler(
	IMapper mapper,
	IDbContext dbContext,
	IOrderDomainService orderDomainService,
	IDeliveryService deliveryService)
	: IRequestHandler<GetOrderByIdQuery, OrderDto>
{
	public async Task<OrderDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
	{
		var order = await dbContext.Orders
		                           .AsNoTracking()
		                           .Include(x => x.Items).ThenInclude(x => x.Product)
		                           .FirstOrDefaultAsync(x => x.Id == query.Id);

		if (order == null) throw new EntityNotFoundException();

		var dto = mapper.Map<OrderDto>(order);
		dto.Total = orderDomainService.GetTotal(order, deliveryService.CalculateDeliveryCost);
		return dto;
	}
}