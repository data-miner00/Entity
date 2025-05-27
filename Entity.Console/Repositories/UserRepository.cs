namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using Entity.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The user repository.
/// </summary>
public sealed class UserRepository : IRepository<User>
{
    private readonly AppDbContext dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The app db context.</param>
    public UserRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await this.dbContext.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var user = await this.dbContext.Users
            .Where(x => x.Id == id)
            .Include(x => x.Credential)
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task CreateAsync(User entity, CancellationToken cancellationToken)
    {
        await this.dbContext.Users.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        var targetUser = await this.dbContext.Users
            .Where(x => x.Id == entity.Id)
            .FirstOrDefaultAsync();

        this.dbContext.Users.Entry(targetUser).CurrentValues.SetValues(targetUser);

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var targetUser = await this.dbContext.Users.SingleOrDefaultAsync(x => x.Id == id)
            ?? throw new InvalidOperationException();

        this.dbContext.Users.Remove(targetUser);
        await this.dbContext.SaveChangesAsync();
    }
}
