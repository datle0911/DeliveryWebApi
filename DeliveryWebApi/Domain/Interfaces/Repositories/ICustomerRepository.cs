namespace DeliveryWebApi.Domain.Interfaces.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    public Task<IEnumerable<Customer>> GetByName(string fullName);
    public Task<Customer?> FindByEmailAsync(string email);
}
