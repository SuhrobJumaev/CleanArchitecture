using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCases;
using UseCases.Order.Commands.CreateOrder;
using UseCases.Order.Queries.GetById;

namespace WebApi.Controllers;

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