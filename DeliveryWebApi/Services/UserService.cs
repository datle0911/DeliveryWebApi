namespace DeliveryWebApi.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly UnitOfWork _unitOfWork;

    public UserService(UserRepository userRepository, UnitOfWork unitOfWork)
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

        _userRepository.Update(user.Result, patchEntity);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(User user)
    {
        _userRepository.Delete(user);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<User>> GetByName(string fullName)
    {
        return await _userRepository.GetByName(fullName);
    }

    public async Task<IEnumerable<User>> GetListAsync()
    {
        return await _userRepository.GetListAsync();
    }

    public async Task<User?> FindByMinimal(MinimalUserViewModel user)
    {
        return await _userRepository.FindByMinimalAsync(user);
    }

    public async Task<User?> GetByUserName(string userName)
    {
        return await _userRepository.FindByUserNameAsync(userName);
    }
}
