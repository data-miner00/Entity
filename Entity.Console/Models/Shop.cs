namespace Entity.Console.Models;

using System.ComponentModel.DataAnnotations;

public class Shop : ECommerceEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public Address? Address { get; set; }

    public ICollection<Product> Products { get; set; }

    public ICollection<Order> Orders { get; set; }

    public long OwnerId { get; set; }

    public User Owner { get; set; }
}
