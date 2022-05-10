namespace DeliveryWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CustomerViewModel customer)
    {
        var resource = new Customer(customer.CustomerUserName, customer.CustomerPassword, customer.CustomerFullName, customer.CustomerPhoneNumber, customer.CustomerEmail);

        await _customerService.AddAsync(resource);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(CustomerViewModel customer)
    {
        var resource = new Customer(customer.CustomerUserName, customer.CustomerPassword, customer.CustomerFullName, customer.CustomerPhoneNumber, customer.CustomerEmail);

        await _customerService.UpdateAsync(resource);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _customerService.GetAllAsync();
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IEnumerable<Customer>> GetByName(string name)
    {
        var customers = await _customerService.GetByName(name);

        return customers;
    }
}
