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

    [Required]
    public Credential Credential { get; set; }

    [Required]
    public UserProfile Profile { get; set; }

    public Shop? Shop { get; set; }

    public ICollection<Order> Orders { get; set; } = null!;
}
