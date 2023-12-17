namespace Entity.Console.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The user entity.
/// </summary>
public class User : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    [Required]
    public string Username { get; set; } = null!;

    /// <summary>
    /// Gets or sets the user credentials.
    /// </summary>
    [Required]
    public Credential Credential { get; set; } = null!;

    /// <summary>
    /// Gets or sets the user profile.
    /// </summary>
    [Required]
    public UserProfile Profile { get; set; } = null!;

    /// <summary>
    /// Gets or sets the shop that the user owns.
    /// </summary>
    public Shop? Shop { get; set; }

    /// <summary>
    /// Gets or sets the orders that the user placed.
    /// </summary>
    public ICollection<Order> Orders { get; set; } = null!;
}
