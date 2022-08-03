namespace DeliveryWebApi.Domain.Interfaces.Services;

public interface IOrderService : IBaseService<Order>
{
    public Task UpdateAsync(string id, JsonPatchDocument<Order> patchEntity);
    public Task<IEnumerable<MinimalOrderViewModel>> GetMinimalListAsync();
}
