namespace DeliveryWebApi.Domain.Interfaces.Services;

public interface IProductService : IBaseService<Product>
{
    public Task AddList(IEnumerable<Product> products);
    public Task<Product?> GetAsync(int id);
    public Task<IEnumerable<MinimalProductViewModel>> GetMinimalListAsync();
}
