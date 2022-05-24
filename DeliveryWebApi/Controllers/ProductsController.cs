namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly IMapper _mapper;
    public ProductsController(ProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(ProductViewModel product)
    {
        var resource = _mapper.Map<ProductViewModel, Product>(product);
        await _productService.AddAsync(resource);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(ProductViewModel product)
    {
        var resource = _mapper.Map<ProductViewModel, Product>(product);
        await _productService.UpdateAsync(resource);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        var products = await _productService.GetListAsync();

        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
    }
}
