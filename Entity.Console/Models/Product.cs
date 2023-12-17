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

    public long SellerId { get; set; }

    public Shop Seller { get; set; }


}
