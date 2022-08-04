﻿using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Add(Order order)
    {
        await _context.Orders.AddAsync(order);
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
    public async Task<IEnumerable<MinimalOrderViewModel>> GetMinimalListAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Details)
            .Select(o => new MinimalOrderViewModel(
                o.OrderId,
                o.Customer.CustomerFullName,
                o.Details.Count,
                o.OrderTimestamp,
                o.OrderAddress,
                o.OrderQrCode,
                o.OrderRobot,
                o.TotalPrice,
                o.OrderStatus,
                o.OrderTracking))
            .ToListAsync();

        return orders;
    }

    public async Task<Order?> FindByIdAsync(string id)
    {
        var resource = await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == id);

        return resource;
    }

    public Task<Order?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}
