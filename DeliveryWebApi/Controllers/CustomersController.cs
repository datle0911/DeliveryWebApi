namespace DeliveryWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomersController(CustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CustomerViewModel customer)
    {
        var mockCustomer = _customerService.FindByEmailAsync(customer.CustomerEmail);
        if(mockCustomer.Result is not null)
        {
            return BadRequest("Customer email existed");
        }

        var resource = _mapper.Map<CustomerViewModel, Customer>(customer);
        await _customerService.AddAsync(resource);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(CustomerViewModel customer)
    {
        var resource = _mapper.Map<CustomerViewModel, Customer>(customer);
        await _customerService.UpdateAsync(resource);

        return Ok();
    }

    [HttpDelete("{customerEmail}")]
    public async Task<IActionResult> DeleteAsync(string customerEmail)
    {
        var resource = _customerService.FindByEmailAsync(customerEmail);
        
        if(resource.Result is null)
        {
            return BadRequest("Customer not found");
        }

        await _customerService.DeleteAsync(resource.Result);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
    {
        var customers = await _customerService.GetAllAsync();

        return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IEnumerable<CustomerViewModel>> GetByName(string name)
    {
        var customers = await _customerService.GetByName(name);

        return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
    }
}
