using AutoMapper;
using DataAccess.Interfaces;
using Email.Interfaces;
using MediatR;
using WebApp.Interfaces;

namespace Mobile.UseCases.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler(
	IMapper mapper,
	IDbContext dbContext,
	IBackgroundJobService backgroundJobService,
	ICurrentUserService currentUserService)
	: IRequestHandler<CreateOrderCommand, int>
{
	public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		var order = mapper.Map<Entities.Models.Order>(command.Dto);

		dbContext.Orders.Add(order);
		await dbContext.SaveChangesAsync();

		backgroundJobService.Schedule<IEmailService>(emailService =>
			emailService.SendAsync(currentUserService.Email, "Order created", $"Order {order.Id} created"));
		return order.Id;
	}
}