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
            detail.Product = await _productRepository.GetAsync(detail.ProductId);
        }
        await _orderRepository.Add(order, customer);
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
