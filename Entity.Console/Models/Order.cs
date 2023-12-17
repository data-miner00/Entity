namespace Entity.Console.Models;

/// <summary>
/// The class to represent an order.
/// </summary>
public sealed class Order : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the date when the order is fulfilled.
    /// </summary>
    public DateTime? OrderFulfilled { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to <see cref="Customer"/>.
    /// </summary>
    public long? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the user that places the order.
    /// </summary>
    public User Customer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the order details.
    /// </summary>
    public ICollection<OrderDetail> OrderDetails { get; set; } = null!;

    /// <summary>
    /// Gets or sets the status of the order.
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to <see cref="Shop"/>.
    /// </summary>
    public long? SellerId { get; set; }

    /// <summary>
    /// Gets or sets the seller of the order.
    /// </summary>
    public Shop Seller { get; set; } = null!;
}
