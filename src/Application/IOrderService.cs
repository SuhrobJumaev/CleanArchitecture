namespace Application;

public interface IOrderService
{
	Task<OrderDto> GetOrderByIdAsync(int id);
}