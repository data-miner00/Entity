namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// The shop that sells products on the platform.
/// </summary>
public class Shop : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the name of the shop.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the description of the shop.
    /// </summary>
    [Required]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the physical address of the shop.
    /// </summary>
    public Address? Address { get; set; }

    /// <summary>
    /// Gets or sets the products that the shop sells.
    /// </summary>
    public ICollection<Product> Products { get; set; } = null!;

    /// <summary>
    /// Gets or sets the orders that the shop receives.
    /// </summary>
    public ICollection<Order> Orders { get; set; } = null!;

    /// <summary>
    /// Gets or sets the foreign key to the owner.
    /// </summary>
    public long OwnerId { get; set; }

    /// <summary>
    /// Gets or sets the user that owns the shop.
    /// </summary>
    public User Owner { get; set; } = null!;
}
