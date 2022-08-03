namespace DeliveryWebApi.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly ProductRepository _productRepository;
    private readonly UnitOfWork _unitOfWork;

    public OrderService(OrderRepository orderRepository, CustomerRepository customerRepository, ProductRepository productRepository, UnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(Order order)
    {
        var customer = await _customerRepository.FindByIdAsync(order.CustomerId);
        foreach(OrderDetail detail in order.Details)
        {
            detail.Product = await _productRepository.FindByIdAsync(detail.ProductId);
        }

        order.Customer = customer;
        _orderRepository.Add(order);
        await _unitOfWork.SaveChanges();
    }

    public async Task UpdateAsync(string id, JsonPatchDocument<Order> patchEntity)
    {
        var order = _orderRepository.FindByIdAsync(id);

        _orderRepository.Update(order.Result, patchEntity);
        await _unitOfWork.SaveChanges();
    }

    public async Task DeleteAsync(Order order)
    {
        _orderRepository.Delete(order);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Order>> GetListAsync()
    {
        return await _orderRepository.GetListAsync();
    }

    public async Task<IEnumerable<MinimalOrderViewModel>> GetMinimalListAsync()
    {
        return await _orderRepository.GetMinimalListAsync();
    }
}
