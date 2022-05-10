using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class OrderRepository : BaseRepository
{
    public OrderRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Add(OrderViewModel order)
    {
        List<OrderDetail> details = new();
        var newOrder = new Order(order.OrderId, order.CustomerId, details, order.OrderDate, order.OrderAddress, order.OrderQrCode, order.OrderRobot, order.TotalPrice, order.OrderStatus, order.OrderTracking);

        var customer = _context.Customers.First(c => c.CustomerId == order.CustomerId);
        newOrder.Customer = customer;

        foreach(OrderDetailViewModel detail in order.Details)
        {
            var product = _context.Products.First(p => p.ProductId == detail.ProductId);
            OrderDetail newDetail = new(order.OrderId, detail.ProductId, product, detail.Quantity, detail.Total);
            newOrder.Details.Add(newDetail);

            _context.OrderDetails.Attach(newDetail);
            _context.Products.Attach(newDetail.Product);
        }
        _context.Customers.Attach(newOrder.Customer);

        //for (int i = 0; i < newOrder.Details.Count; i++)
        //{
        //    _context.OrderDetails.Attach(newOrder.Details[i]);
        //    _context.Products.Attach(newOrder.Details[i].Product);
        //}

        await _context.AddAsync(newOrder);
        await _context.AddRangeAsync(newOrder.Details);
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task<IEnumerable<Order>> GetListAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Details)
                .ThenInclude(o => o.Product)
            .AsNoTracking()
            .ToListAsync();

        return orders;
    }
}
