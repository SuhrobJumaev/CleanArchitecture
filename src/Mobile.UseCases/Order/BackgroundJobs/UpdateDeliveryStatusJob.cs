using DataAccess.Interfaces;
using Delivery.Interfaces;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Mobile.UseCases.Order.BackgroundJobs;

public class UpdateDeliveryStatusJob(IDbContext dbContext, IDeliveryService deliveryService) : IJob
{
	public async Task ExecuteAsync()
	{
		var orders = await dbContext.Orders.Where(x => x.Status == OrderStatus.Created).ToListAsync();

		var items = orders.Select(x => new { Order = x, Task = deliveryService.IsDeliveredAsync(x.Id) }).ToList();

		await Task.WhenAll(items.Select(x => x.Task));

		foreach (var item in items)
			if (item.Task.Result)
				item.Order.Status = OrderStatus.Delivered;

		await dbContext.SaveChangesAsync();
	}
}