namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IHubContext<RealtimeHub> _realtimeHub; 

    public CustomersController(ICustomerService customerService, IMapper mapper, IHubContext<RealtimeHub> realtimeHub)
    {
        _customerService = customerService;
        _mapper = mapper;
        _realtimeHub = realtimeHub;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CustomerViewModel customer)
    {
        // Check if existed
        var mockCustomer = _customerService.FindByEmailAsync(customer.CustomerEmail);
        if(mockCustomer.Result is not null)
        {
            var warning = new Message(Contents.ExistedObject + "Customer");
            return BadRequest(warning.Content);
        }

        // Add and Save to Database
        var resource = _mapper.Map<CustomerViewModel, Customer>(customer);
        await _customerService.AddAsync(resource);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPost + "Customer " + customer.CustomerUserName + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(int id, [FromBody] JsonPatchDocument<Customer> patchEntity)
    {
        // Update to Database
        await _customerService.UpdateAsync(id, patchEntity);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPutPatch + "Customer with ID: " + id.ToString() + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpDelete("{customerEmail}")]
    public async Task<IActionResult> DeleteAsync(string customerEmail)
    {
        // Check if not existed
        var resource = _customerService.FindByEmailAsync(customerEmail);
        
        if(resource.Result is null)
        {
            var notification = new Message(Contents.NotFoundObject + "Customer");
            return BadRequest(notification);
        }

        // Delete
        await _customerService.DeleteAsync(resource.Result);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyDelete + "Customer with email " + customerEmail + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpGet]
    public async Task<IEnumerable<CustomerViewModel>> GetListAsync()
    {
        var customers = await _customerService.GetListAsync();

        return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
    }

    [HttpGet("{name}")]
    public async Task<IEnumerable<CustomerViewModel>> GetByFullNameAsync(string name)
    {
        var customers = await _customerService.GetByFullNameAsync(name);

        return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
    }
}
