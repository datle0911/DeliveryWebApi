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

    [HttpPut]
    public async Task<IActionResult> PutAsync(SaveOrderViewModel order)
    {
        //var resource = new Order(order.CustomerId, order.Details, order.OrderDate, order.OrderAddress, order.OrderQrCode, order.OrderRobot, order.TotalPrice, order.OrderStatus, order.OrderTracking);

        var resource = _mapper.Map<SaveOrderViewModel, Order>(order);
        await _orderService.UpdateAsync(resource);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
    {
        var orders = await _orderService.GetOrdersAsync();

        return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);
    }
}
