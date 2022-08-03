namespace DeliveryWebApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(User user)
    {
        await _userRepository.Add(user);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(int id, JsonPatchDocument<User> patchEntity)
    {
        var user = _userRepository.FindByIdAsync(id);

        patchEntity.ApplyTo(user.Result);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(User user)
    {
        _userRepository.Delete(user);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<User>> GetByNameAsync(string fullName)
    {
        return await _userRepository.GetByNameAsync(fullName);
    }

    public async Task<IEnumerable<User>> GetListAsync()
    {
        return await _userRepository.GetListAsync();
    }

    public async Task<User?> FindByMinimal(MinimalUserViewModel user)
    {
        return await _userRepository.FindByMinimalAsync(user);
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        return await _userRepository.FindByUserNameAsync(userName);
    }
}
