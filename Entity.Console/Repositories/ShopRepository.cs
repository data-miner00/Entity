namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using System.Collections.Generic;
using System.Linq;

public sealed class ShopRepository
{
    private readonly AppDbContext dbContext;

    public ShopRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Shop? GetById(long id)
    {
        var shop = this.dbContext.Shops
            .Where(s => s.Id == id)
            .FirstOrDefault();

        return shop;
    }

    public IEnumerable<Shop> GetAll()
    {
        var shops = this.dbContext.Shops
            .ToList();

        return shops;
    }

    public Shop? GetUserShop(long userId)
    {
        var shop = this.dbContext.Shops
            .Where(x => x.OwnerId == userId)
            .FirstOrDefault();

        return shop;
    }

    public void Update(Shop shop)
    {
        var targetShop = this.dbContext.Shops
            .Where(x => x.Id == shop.Id)
            .FirstOrDefault();

        this.dbContext.Shops.Entry(targetShop).CurrentValues.SetValues(shop);

        this.dbContext.SaveChanges();
    }

    public void Delete(long id)
    {
        var targetShop = this.dbContext.Shops
            .Where(x => x.Id == id)
            .First();

        this.dbContext.Shops.Remove(targetShop);
        this.dbContext.SaveChanges();
    }
}
