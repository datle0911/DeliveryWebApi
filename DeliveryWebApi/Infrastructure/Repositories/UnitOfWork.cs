using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class UnitOfWork : BaseRepository
{
    public UnitOfWork(DeliveryDbContext dbContext) : base(dbContext)
    {
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
