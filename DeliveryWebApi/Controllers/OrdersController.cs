namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : Controller
{

    private readonly OrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(OrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(SaveOrderViewModel order)
    {
        var resource = _mapper.Map<SaveOrderViewModel, Order>(order);
        await _orderService.AddAsync(resource);

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(string id, [FromBody] JsonPatchDocument<Order> patchEntity)
    {
        await _orderService.UpdateAsync(id, patchEntity);

        return Ok();
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
