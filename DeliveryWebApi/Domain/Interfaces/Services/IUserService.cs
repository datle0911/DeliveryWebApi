namespace DeliveryWebApi.Domain.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
    public Task UpdateAsync(int id, JsonPatchDocument<User> patchEntity);
    public Task<IEnumerable<User>> GetByNameAsync(string fullName);
    public Task<User?> FindByMinimal(MinimalUserViewModel user);
    public Task<User?> GetByUserNameAsync(string userName);
}
