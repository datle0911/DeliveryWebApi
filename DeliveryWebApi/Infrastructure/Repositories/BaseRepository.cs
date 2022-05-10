using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class BaseRepository
{
    protected DeliveryDbContext _context { get; set; }

    public BaseRepository(DeliveryDbContext dbContext)
    {
        _context = dbContext;
    }
}
