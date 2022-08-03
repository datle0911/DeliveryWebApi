namespace DeliveryWebApi.Domain.Interfaces.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<Order?> FindByIdAsync(string id);
    public Task<IEnumerable<MinimalOrderViewModel>> GetMinimalListAsync();
}
