using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mobile.UseCases;
using Mobile.UseCases.Order.Commands.CreateOrder;
using Mobile.UseCases.Order.Queries.GetById;

namespace Mobile.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(ISender sender) : ControllerBase
{
	[HttpGet("{id}")]
	public async Task<OrderDto> Get(int id)
	{
		return await sender.Send(new GetOrderByIdQuery { Id = id });
	}

	[HttpPost]
	public async Task<int> Create([FromBody] CreateOrderDto dto)
	{
		return await sender.Send(new CreateOrderCommand { Dto = dto });
	}
}