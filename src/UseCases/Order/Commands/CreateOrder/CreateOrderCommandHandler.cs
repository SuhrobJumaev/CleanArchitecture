using AutoMapper;
using DataAccess.Interfaces;
using MediatR;

namespace UseCases.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler(IMapper mapper, IDbContext dbContext) : IRequestHandler<CreateOrderCommand, int>
{
	public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		var order = mapper.Map<Domain.Entities.Order>(command.Dto);

		dbContext.Orders.Add(order);
		await dbContext.SaveChangesAsync();
		return order.Id;
	}
}