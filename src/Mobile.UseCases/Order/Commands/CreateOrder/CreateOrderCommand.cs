using MediatR;

namespace Mobile.UseCases.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
	public CreateOrderDto Dto { get; set; }
}