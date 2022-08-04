namespace DeliveryWebApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddList(IEnumerable<Product> products)
    {
        await _productRepository.AddList(products);
        await _unitOfWork.SaveChanges();
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _productRepository.FindByIdAsync(id);
    }
    public async Task AddAsync(Product product)
    {
        await _productRepository.Add(product);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(int id, JsonPatchDocument<Product> patchEntity)
    {
        var product = _productRepository.FindByIdAsync(id);

        patchEntity.ApplyTo(product.Result);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(Product product)
    {
        _productRepository.Delete(product);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Product>> GetListAsync()
    {
        return await _productRepository.GetListAsync();
    }

    public async Task<IEnumerable<MinimalProductViewModel>> GetMinimalListAsync()
    {
        return await _productRepository.GetAllMinimalAsync();
    }
}
