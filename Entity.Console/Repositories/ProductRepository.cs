namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class ProductRepository
{
    private readonly AppDbContext dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Product? GetById(long id)
    {
        var product = this.dbContext.Products
            .Where(p => p.Id == id)
            .Include(x => x.OrderDetails)
            .FirstOrDefault();

        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        var products = this.dbContext.Products
            .Include(x => x.OrderDetails)
            .ToList();
        return products;
    }

    public IEnumerable<Product> GetShopProducts(long shopId)
    {
        var products = this.dbContext.Products
            .Where(x => x.SellerId == shopId)
            .Include(x => x.OrderDetails)
            .ToList();

        return products;
    }

    public void Add(Product product)
    {
        this.dbContext.Products.Add(product);
        this.dbContext.SaveChanges();
    }

    public void Update(Product product)
    {
        var targetProduct = this.dbContext.Products
            .FirstOrDefault(x => x.Id == product.Id) ?? throw new InvalidOperationException();

        this.dbContext.Products
            .Entry(targetProduct)
            .CurrentValues
            .SetValues(product);

        this.dbContext.SaveChanges();
    }

    public void Delete(long id)
    {
        var targetProduct = this.dbContext.Products.FirstOrDefault(x => x.Id == id);
        this.dbContext.Products.Remove(targetProduct);
        this.dbContext.SaveChanges();
    }
}
