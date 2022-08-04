using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddList(IEnumerable<Product> products)
    {
        await _context.Products.AddRangeAsync(products);
    }

    public async Task<Product?> FindByIdAsync(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);

        return product;
    }

    public async Task<IEnumerable<Product>> GetListAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<MinimalProductViewModel>> GetAllMinimalAsync()
    {
        return await _context.Products
            .Select(p => new MinimalProductViewModel(
                p.ProductId,
                p.ProductName,
                p.Description,
                p.ProductPrice,
                p.ProductStatus))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Product product)
    {
        await _context.AddAsync(product);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
    }

}
