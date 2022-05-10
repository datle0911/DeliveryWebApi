namespace DeliveryWebApi.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly UnitOfWork _unitOfWork;

    public CustomerService(CustomerRepository customerRepository, UnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(Customer customer)
    {
        await _customerRepository.Add(customer);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _customerRepository.Update(customer);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(Customer customer)
    {
        _customerRepository.Delete(customer);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Customer>> GetByName(string fullName)
    {
        return await _customerRepository.GetByName(fullName);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }
}
