namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using System.Collections.Generic;
using System.Linq;

public sealed class AddressRepository
{
    private readonly AppDbContext dbContext;

    public AddressRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Address? GetById(long id)
    {
        var address = this.dbContext.Addresses.FirstOrDefault(a => a.Id == id);
        return address;
    }

    public IEnumerable<Address> GetAll()
    {
        var addresses = this.dbContext.Addresses.ToList();
        return addresses;
    }

    public void Update(Address address)
    {
        var targetAddress = this.dbContext.Addresses.FirstOrDefault(x => x.Id == address.Id);
        this.dbContext.Addresses
            .Entry(targetAddress)
            .CurrentValues
            .SetValues(address);
        this.dbContext.SaveChanges();
    }
}
