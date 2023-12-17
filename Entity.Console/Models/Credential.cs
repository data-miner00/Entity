namespace Entity.Console.Models;

public class Credential : ECommerceEntity
{
    public long UserId { get; set; }

    public User User { get; set; }

    public string HashedPassword { get; set; }

    public string Salt { get; set; }

    public string HashAlgorithm { get; set; }
}
