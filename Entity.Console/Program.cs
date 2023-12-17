using Entity.Console.Data;
using Entity.Console.Models;
using static Entity.Console.Seeds.SeedUsers;

Seed();

static void QueryRecords()
{
    using var context = new AppDbContext();

    var products = context.Products
        .Where(p => p.Price > 10.00M)
        .OrderBy(p => p.Name);

    var products2 = from product in context.Products
                    where product.Price > 10.00M
                    orderby product.Name
                    select product;

    foreach (var product in products)
    {
        Console.WriteLine("Id: " + product.Id);
        Console.WriteLine("Name: " + product.Name);
        Console.WriteLine("Price: " + product.Price);
        Console.WriteLine(new string('-', 20));
    }
}

static void UpdateRecord()
{
    using var context = new AppDbContext();
    var veggieSpecial = context.Products
        .Where(p => p.Name == "Veggie Special Pizza")
        .FirstOrDefault();

    if (veggieSpecial is Product)
    {
        veggieSpecial.Price = 10.99M;
    }

    context.SaveChanges();
}

static void InsertRecords()
{
    using var context = new AppDbContext();

    var veggieSpecial = new Product
    {
        Name = "Veggie Special Pizza",
        Price = 9.99M,
        Description = "Description for veggie pizza",
    };

    context.Products.Add(veggieSpecial);

    var deluxeMeat = new Product
    {
        Name = "Deluxe Meat Pizza",
        Price = 19.99M,
        Description = "Description for deluxe meat",
    };

    context.Add(deluxeMeat);

    context.SaveChanges();
}

static void RemoveRecord()
{
    using var context = new AppDbContext();
    var veggieSpecial = context.Products
        .Where(p => p.Name == "Veggie Special Pizza")
        .FirstOrDefault();

    context.Remove(veggieSpecial!);

    context.SaveChanges(true);
}
