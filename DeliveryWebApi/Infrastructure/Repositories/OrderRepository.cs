using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class OrderRepository : BaseRepository
{
    public OrderRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Add(Order order)
    {
        throw new NotImplementedException();
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task<IEnumerable<Order>> GetListAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Details)
                .ThenInclude(o => o.Product)
            .AsNoTracking()
            .ToListAsync();

        return orders;
    }
}
