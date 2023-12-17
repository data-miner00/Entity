namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// The user profile entity.
/// </summary>
public sealed class UserProfile : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [EmailAddress]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    [Phone]
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Gets or sets the shipping address of the user.
    /// </summary>
    public Address Address { get; set; } = null!;

    /// <summary>
    /// Gets or sets the foreign key to the user.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the user that owns this instance.
    /// </summary>
    public User User { get; set; } = null!;
}
