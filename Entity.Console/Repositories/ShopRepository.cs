namespace Entity.Console.Repositories;

using Entity.Common;
using Entity.Console.Data;
using Entity.Console.Models;
using Entity.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public sealed class ShopRepository : IRepository<Shop>
{
    private readonly AppDbContext dbContext;

    public ShopRepository(AppDbContext dbContext)
    {
        this.dbContext = Guard.ThrowIfNull(dbContext);
    }

    public async Task<Shop?> GetUserShopAsync(long userId)
    {
        var shop = await this.dbContext.Shops
            .Where(x => x.OwnerId == userId)
            .FirstOrDefaultAsync();

        return shop;
    }

    public async Task<IEnumerable<Shop>> GetAllAsync(CancellationToken cancellationToken)
    {
        var shops = await this.dbContext.Shops
            .ToListAsync();

        return shops;
    }

    public async Task<Shop> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var shop = await this.dbContext.Shops
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();

        return shop;
    }

    public async Task CreateAsync(Shop entity, CancellationToken cancellationToken)
    {
        await this.dbContext.Shops.AddAsync(entity, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Shop entity, CancellationToken cancellationToken)
    {
        var targetShop = await this.dbContext.Shops
            .Where(x => x.Id == entity.Id)
            .FirstOrDefaultAsync();

        this.dbContext.Shops.Entry(targetShop).CurrentValues.SetValues(targetShop);

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var targetShop = await this.dbContext.Shops
            .Where(x => x.Id == id)
            .FirstAsync();

        this.dbContext.Shops.Remove(targetShop);
        await this.dbContext.SaveChangesAsync();
    }
}
