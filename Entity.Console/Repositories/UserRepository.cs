namespace Entity.Console.Repositories;

using Entity.Console.Data;
using Entity.Console.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The user repository.
/// </summary>
public sealed class UserRepository
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

    public User? GetById(long id)
    {
        var user = this.dbContext.Users
            .Where(x => x.Id == id)
            .Include(x => x.Credential)
            .FirstOrDefault();

        return user;
    }

    public User? GetByUsername(string username)
    {
        var user = this.dbContext.Users.SingleOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        return user;
    }

    public IList<User> GetAll()
    {
        var users = this.dbContext.Users.ToList();
        return users;
    }

    public void Insert(User user)
    {
        this.dbContext.Users.Add(user);
        this.dbContext.SaveChanges();
    }

    public void Delete(long id)
    {
        var targetUser = this.dbContext.Users.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();

        this.dbContext.Users.Remove(targetUser);
        this.dbContext.SaveChanges();
    }
}
