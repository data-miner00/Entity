namespace Entity.Console.Models;

public class OrderDetail : ECommerceEntity
{
    public int Quantity { get; set; }

    public long ProductId { get; set; }

    public long OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public Product Product { get; set; } = null!;
}
