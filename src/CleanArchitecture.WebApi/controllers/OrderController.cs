using CleanArchitecture.Application;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
	[HttpGet("{id}")]
	public async Task<OrderDto> Get(int id)
	{
		return await orderService.GetOrderByIdAsync(id);
	}
}