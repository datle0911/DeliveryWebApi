using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository
{
    public CustomerRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Add(Customer customer)
    {
        await _context.AddAsync(customer);
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void Delete(Customer customer)
    {
        _context.Customers.Remove(customer);
    }

    public async Task<IEnumerable<Customer>> GetByName(string fullName)
    {
        var customer = await _context.Customers
            .Where(c => c.CustomerFullName == fullName)
            .ToListAsync();

        return customer;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = await _context.Customers
            .AsNoTracking()
            .ToListAsync();

        return customers;
    }
}
