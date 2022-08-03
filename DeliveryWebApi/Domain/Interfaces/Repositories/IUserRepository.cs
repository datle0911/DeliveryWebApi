namespace DeliveryWebApi.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<IEnumerable<User>> GetByNameAsync(string fullName);
    public Task<User?> FindByMinimalAsync(MinimalUserViewModel user);
    public Task<User?> FindByUserNameAsync(string userName);
}
