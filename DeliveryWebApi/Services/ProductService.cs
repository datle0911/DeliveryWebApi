namespace DeliveryWebApi.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly UnitOfWork _unitOfWork;

    public ProductService(ProductRepository productRepository, UnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddList(IEnumerable<Product> products)
    {
        _productRepository.AddList(products);
        await _unitOfWork.SaveChanges();
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _productRepository.GetAsync(id);
    }
    public async Task AddAsync(Product product)
    {
        await _productRepository.Add(product);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(Product product)
    {
        _productRepository.Update(product);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(Product product)
    {
        _productRepository.Delete(product);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Product>> GetListAsync()
    {
        return await _productRepository.GetAllAsync();
    }
}
