namespace DeliveryWebApi.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly UnitOfWork _unitOfWork;

    public OrderService(OrderRepository orderRepository, UnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(Order order)
    {
        await _orderRepository.Add(order);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(Order order)
    {
        _orderRepository.Update(order);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(Order order)
    {
        _orderRepository.Delete(order);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetListAsync();
    }
}
