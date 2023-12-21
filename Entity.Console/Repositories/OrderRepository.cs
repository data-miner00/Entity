namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using Microsoft.EntityFrameworkCore;

public sealed class OrderRepository
{
    private readonly AppDbContext dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Order? GetById(long id)
    {
        var order = this.dbContext.Orders
            .Where(x => x.Id == id)
            .Include(x => x.OrderDetails)
            .FirstOrDefault();

        return order;
    }

    public IEnumerable<Order> GetAll()
    {
        var orders = this.dbContext.Orders.ToList();
        return orders;
    }

    public IEnumerable<Order> GetUserOrders(long userId)
    {
        var orders = this.dbContext.Orders
            .Where(x => x.CustomerId == userId)
            .Include(x => x.OrderDetails)
            .ToList();

        return orders;
    }

    public void Add(Order order)
    {
        this.dbContext.Orders.Add(order);
        this.dbContext.SaveChanges();
    }

    public void Update(Order order)
    {
        var original = this.dbContext.Orders
            .FirstOrDefault(x => x.Id == order.Id) ?? throw new InvalidOperationException("Invalid order Id");

        this.dbContext.Entry(original).CurrentValues.SetValues(order);
        this.dbContext.SaveChanges();
    }

    public void Delete(long id)
    {
        var targetOrder = this.dbContext.Orders.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();

        this.dbContext.Orders.Remove(targetOrder);
        this.dbContext.SaveChanges();
    }
}
