namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// The product entity.
/// </summary>
public class Product : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    [Required]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the seller.
    /// </summary>
    public long SellerId { get; set; }

    /// <summary>
    /// Gets or sets the seller of the product.
    /// </summary>
    public Shop Seller { get; set; } = null!;

    /// <summary>
    /// Gets or sets the list of ordered item that belongs to this product.
    /// </summary>
    public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
}
