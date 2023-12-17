namespace Entity.Console.Models;

/// <summary>
/// The details of the item in an order.
/// </summary>
public class OrderDetail : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the quantities ordered.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to <see cref="Entity.Console.Models.Order"/>.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    /// Gets or sets the order that this instance belongs to.
    /// </summary>
    public Order Order { get; set; } = null!;

    /// <summary>
    /// Gets or sets the foreign key to the <see cref="Product"/>.
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product of this detail.
    /// </summary>
    public Product Product { get; set; } = null!;
}
