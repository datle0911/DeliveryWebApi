using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class UserRepository : BaseRepository
{
    public UserRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Add(User user)
    {
        await _context.AddAsync(user);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetByName(string fullName)
    {
        var users = await _context.Users
            .Where(c => c.FullName == fullName)
            .ToListAsync();

        return users;
    }

    public async Task<IEnumerable<User>> GetListAsync()
    {
        var users = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        return users;
    }
}
