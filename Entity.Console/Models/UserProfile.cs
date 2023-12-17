namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations;

public sealed class UserProfile : ECommerceEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    public Address Address { get; set; } = null!;

    public long UserId { get; set; }

    public User User { get; set; } = null!;
}
