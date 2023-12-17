namespace Entity.Console.Models;

/// <summary>
/// The class that contains sensitive information for a <see cref="User"/>.
/// </summary>
public class Credential : ECommerceEntity
{
    /// <summary>
    /// Gets or sets the foreign key to <see cref="User"/>.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the user that owns this instance.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets the hashed password.
    /// </summary>
    public string HashedPassword { get; set; } = null!;

    /// <summary>
    /// Gets or sets the salt used for hashing the password.
    /// </summary>
    public string Salt { get; set; } = null!;

    /// <summary>
    /// Gets or sets the algorithm used for hashing the password.
    /// </summary>
    public string HashAlgorithm { get; set; } = null!;
}
