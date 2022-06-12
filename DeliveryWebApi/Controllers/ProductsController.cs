namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly IMapper _mapper;
    private readonly IHubContext<RealtimeHub> _realtimeHub;
    public ProductsController(ProductService productService, IMapper mapper, IHubContext<RealtimeHub> realtimeHub)
    {
        _productService = productService;
        _mapper = mapper;
        _realtimeHub = realtimeHub;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(ProductViewModel product)
    {
        // Add and Save to Database
        var resource = _mapper.Map<ProductViewModel, Product>(product);
        await _productService.AddAsync(resource);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPost + "Product " + product.ProductName + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(int id, [FromBody] JsonPatchDocument<Product> patchEntity)
    {
        // Update Product
        await _productService.UpdateAsync(id, patchEntity);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPutPatch + "Product with ID: " + id.ToString() + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        // Check if not existed
        var resource = _productService.GetAsync(id);
        
        if(resource.Result is null)
        {
            var warning = new Message(Contents.NotFoundObject + "Product");
            return BadRequest(warning.Content);
        }

        // Delete Product
        await _productService.DeleteAsync(resource.Result);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyDelete + "Product with ID: " + id.ToString() + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] bool minimal)
    {
        if(minimal == true)
        {
            var minimalProducts = await _productService.GetMinimalListAsync();

            return Ok(minimalProducts);
        }

        else
        {
            var products = await _productService.GetListAsync();

            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products));
        }
    }
}
