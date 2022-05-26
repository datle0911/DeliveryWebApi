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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var resource = _productService.GetAsync(id);
        
        if(resource.Result is null)
        {
            return BadRequest("Product Not Found");
        }

        await _productService.DeleteAsync(resource.Result);
        return Ok();
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
