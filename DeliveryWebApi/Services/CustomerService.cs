namespace DeliveryWebApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(Customer customer)
    {
        await _customerRepository.Add(customer);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(int id, JsonPatchDocument<Customer> patchEntity)
    {
        var customer = _customerRepository.FindByIdAsync(id);

        patchEntity.ApplyTo(customer.Result);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(Customer customer)
    {
        _customerRepository.Delete(customer);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Customer>> GetByFullNameAsync(string fullName)
    {
        return await _customerRepository.GetByName(fullName);
    }

    public async Task<IEnumerable<Customer>> GetListAsync()
    {
        return await _customerRepository.GetListAsync();
    }

    public async Task<Customer> FindByEmailAsync(string email)
    {
        return await _customerRepository.FindByEmailAsync(email);
    }

}
