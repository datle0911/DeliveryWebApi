namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : Controller
{

    private readonly OrderService _orderService;
    private readonly IMapper _mapper;
    private readonly IHubContext<RealtimeHub> _realtimeHub;

    public OrdersController(OrderService orderService, IMapper mapper, IHubContext<RealtimeHub> realtimeHub)
    {
        _orderService = orderService;
        _mapper = mapper;
        _realtimeHub = realtimeHub;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(SaveOrderViewModel order)
    {
        // Add Order
        var resource = _mapper.Map<SaveOrderViewModel, Order>(order);
        await _orderService.AddAsync(resource);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPost + "Order. Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(string id, [FromBody] JsonPatchDocument<Order> patchEntity)
    {
        // Update Order
        await _orderService.UpdateAsync(id, patchEntity);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPutPatch + "Order " + id + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] bool minimal)
    {
        if(minimal is true)
        {
            var orders = await _orderService.GetMinimalOrdersAsync();

            return Ok(orders);
        }

        else
        {
            var orders = await _orderService.GetOrdersAsync();

            return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders));
        }
    }
}
