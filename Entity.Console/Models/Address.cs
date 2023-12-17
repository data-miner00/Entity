namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations.Schema;

public sealed class Address : ECommerceEntity
{
    public long? UserProfileId { get; set; }

    [ForeignKey("UserProfileId")]
    public UserProfile? UserProfile { get; set; }

    public long? ShopId { get; set; }

    [ForeignKey("ShopId")]
    public Shop? Shop { get; set; }

    public string Street1 { get; set; }

    public string? Street2 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }

    public string Country { get; set; }
}
