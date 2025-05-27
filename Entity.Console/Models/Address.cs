namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// The class that contains the information of an location address.
/// </summary>
public sealed class Address : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the foreign key for <see cref="UserProfile"/>.
    /// </summary>
    public long? UserProfileId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="UserProfile"/> that owns this instance.
    /// </summary>
    [ForeignKey(nameof(UserProfileId))]
    public UserProfile? UserProfile { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for <see cref="Shop"/>.
    /// </summary>
    public long? ShopId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Shop"/> that owns this instance.
    /// </summary>
    [ForeignKey(nameof(ShopId))]
    public Shop? Shop { get; set; }

    /// <summary>
    /// Gets or sets the first street of the address.
    /// </summary>
    public string Street1 { get; set; } = null!;

    /// <summary>
    /// Gets or sets the second street of the address.
    /// </summary>
    public string? Street2 { get; set; }

    /// <summary>
    /// Gets or sets the city of the address.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the state of the address.
    /// </summary>
    public string State { get; set; } = null!;

    /// <summary>
    /// Gets or sets the postal code of the address.
    /// </summary>
    public string PostalCode { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country of the address.
    /// </summary>
    public string Country { get; set; } = null!;
}
