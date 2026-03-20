using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem> Items { get; set; }

    public decimal GetTotal()
    {
        return Items.Sum(x => x.Quantity * x.Product.Price);
    }
}