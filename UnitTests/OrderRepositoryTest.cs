namespace UnitTests;

public class OrderRepositoryTest
{
    private void Seed(DeliveryDbContext dbContext)
    {
        var customers = new List<Customer>()
        {
            new Customer(1, "datleqn", "datle123", "Le Thanh Dat", "09991199", "dat.lt@kyanon"),
            new Customer(2, "datlezzz", "datle123", "Chua He", "0123456", "chua.he@kyanon"),
            new Customer(3, "datleqn123", "datle123", "Sieu Nhan", "6543210", "somebody.unknown@kyanon"),
            new Customer(4, "chuahezz", "datle123", "Chua He", "9999999", "he.chua@kyanon"),

        };

        var orderDetails = new List<OrderDetail>()
        {
            new OrderDetail("a", 1, null, 2, 24),
            new OrderDetail("a", 2, null, 3, 36)
        };

        var orders = new List<Order>()
        {
            new Order("a", 1, null, orderDetails, DateTime.Now, "69 Mai Chi Tho", "code 1", "robot A", 12, EOrderStatus.pending, EOrderTracking.packing)
        };

        dbContext.Customers.AddRange(customers);
        dbContext.Orders.AddRange(orders);
        dbContext.SaveChanges();
    }

    [Fact]
    public async Task GetMinimalListAsync_OnSuccess_ReturnsOrdersMinimalList()
    {
        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "GetMinimalListAsync")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new OrderRepository(context);

        var result = await repository.GetMinimalListAsync();

        Assert.Equal(2, result.First().NumberOfDetails);
    }
}
