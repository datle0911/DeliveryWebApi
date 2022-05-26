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

    public async Task<User?> FindByMinimalAsync(MinimalUserViewModel user)
    {
        var resource = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.UserName == user.UserName &&
                u.Password == user.Password);

        return resource;
    }

    public async Task<User?> FindByUserNameAsync(string userName)
    {
        var resource = await _context.Users
            .FirstOrDefaultAsync(u =>
            u.UserName == userName);

        return resource;
    }
}
