namespace DeliveryWebApi.Domain.Interfaces.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task AddList(IEnumerable<Product> products);
    public Task<IEnumerable<MinimalProductViewModel>> GetAllMinimalAsync();
}
