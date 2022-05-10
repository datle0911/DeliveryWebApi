namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly ProductService _productService;
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Product product)
    {
        await _productService.AddAsync(product);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Product product)
    {
        await _productService.UpdateAsync(product);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _productService.GetListAsync();

        return products;
    }
}
