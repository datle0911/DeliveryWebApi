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
    public async Task<IActionResult> PostAsync(ProductViewModel product)
    {
        var resource = new Product(product.ProductName, product.Description, product.ProductImage, product.ProductPrice, product.ProductStatus);

        await _productService.AddAsync(resource);

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
