namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using Entity.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public sealed class ProductRepository : IRepository<Product>
{
    private readonly AppDbContext dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetShopProductsAsync(long shopId)
    {
        var products = await this.dbContext.Products
            .Where(x => x.SellerId == shopId)
            .Include(x => x.OrderDetails)
            .ToListAsync();

        return products;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await this.dbContext.Products
            .Include(x => x.OrderDetails)
            .ToListAsync();
        return products;
    }

    public async Task<Product> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var product = await this.dbContext.Products
            .Where(p => p.Id == id)
            .Include(x => x.OrderDetails)
            .FirstOrDefaultAsync();

        return product;
    }

    public async Task CreateAsync(Product entity, CancellationToken cancellationToken)
    {
        await this.dbContext.Products.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity, CancellationToken cancellationToken)
    {
        var targetProduct = await this.dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new InvalidOperationException();

        this.dbContext.Products
            .Entry(targetProduct)
            .CurrentValues
            .SetValues(entity);

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var targetProduct = await this.dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        this.dbContext.Products.Remove(targetProduct);
        await this.dbContext.SaveChangesAsync();
    }
}
