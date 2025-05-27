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

public sealed class AddressRepository : IRepository<Address>
{
    private readonly AppDbContext dbContext;

    public AddressRepository(AppDbContext dbContext)
    {
        this.dbContext = Guard.ThrowIfNull(dbContext);
    }

    public async Task<IEnumerable<Address>> GetAllAsync(CancellationToken cancellationToken)
    {
        var addresses = await this.dbContext.Addresses.ToListAsync();
        return addresses;
    }

    public async Task<Address> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var address = await this.dbContext.Addresses
            .FirstOrDefaultAsync(a => a.Id == id);
        return address;
    }

    public async Task CreateAsync(Address entity, CancellationToken cancellationToken)
    {
        await this.dbContext.Addresses.AddAsync(entity, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Address entity, CancellationToken cancellationToken)
    {
        var targetAddress = this.dbContext.Addresses.FirstOrDefault(x => x.Id == entity.Id);
        this.dbContext.Addresses
            .Entry(targetAddress)
            .CurrentValues
            .SetValues(entity);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var address = await this.dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        this.dbContext.Addresses.Remove(address);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
