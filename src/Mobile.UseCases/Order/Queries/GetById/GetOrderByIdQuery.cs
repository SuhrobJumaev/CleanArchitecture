using MediatR;

namespace Mobile.UseCases.Order.Queries.GetById;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
	public int Id { get; set; }
}