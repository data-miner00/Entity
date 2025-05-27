namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using Entity.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public sealed class OrderRepository : IRepository<Order>
{
    private readonly AppDbContext dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orders = await this.dbContext.Orders.ToListAsync();
        return orders;
    }

    public async Task<Order> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var order = await this.dbContext.Orders
            .Where(x => x.Id == id)
            .Include(x => x.OrderDetails)
            .FirstOrDefaultAsync();

        return order;
    }

    public async Task CreateAsync(Order entity, CancellationToken cancellationToken)
    {
        await this.dbContext.Orders.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity, CancellationToken cancellationToken)
    {
        var original = await this.dbContext.Orders
            .FirstOrDefaultAsync(x => x.Id == entity.Id)
            ?? throw new InvalidOperationException("Invalid order Id");

        this.dbContext.Entry(original).CurrentValues.SetValues(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var targetOrder = await this.dbContext.Orders.SingleOrDefaultAsync(x => x.Id == id)
            ?? throw new InvalidOperationException();

        this.dbContext.Orders.Remove(targetOrder);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(long userId)
    {
        var orders = await this.dbContext.Orders
            .Where(x => x.CustomerId == userId)
            .Include(x => x.OrderDetails)
            .ToListAsync();

        return orders;
    }
}
