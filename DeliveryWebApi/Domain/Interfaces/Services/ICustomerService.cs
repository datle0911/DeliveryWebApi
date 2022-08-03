namespace DeliveryWebApi.Domain.Interfaces.Services;

public interface ICustomerService : IBaseService<Customer>
{
    public Task<IEnumerable<Customer>> GetByFullNameAsync(string fullName);
    public Task<Customer> FindByEmailAsync(string email);
}
