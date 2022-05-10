namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : Controller
{

    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(OrderViewModel order)
    {
        await _orderService.AddAsync(order);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Order order)
    {
        await _orderService.UpdateAsync(order);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await _orderService.GetOrdersAsync();

        return orders;
    }
}
