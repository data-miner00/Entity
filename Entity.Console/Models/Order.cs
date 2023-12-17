namespace Entity.Console.Models;

public class Order : ECommerceEntity
{
    public DateTime? OrderFulfilled { get; set; }

    public long? CustomerId { get; set; }

    public User Customer { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; }

    public OrderStatus Status { get; set; }

    public long? SellerId { get; set; }

    public Shop Seller { get; set; } = null!;
}
