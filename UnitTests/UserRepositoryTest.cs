namespace UnitTests;

public class UserRepositoryTest
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

        var users = new List<User>()
        {
            new User("admin1", "123", "Quan Tri Vien 1", "12345", ERoles.user ),
            new User("admin2", "234", "Quan Tri Vien 2", "233456", ERoles.admin)
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
        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();
    }

    [Fact]
    public async Task GetAllAsync_OnSuccess_ReturnsAllCustomers()
    {
        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "ReturnsAllCustomers")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new UserRepository(context);

        var result = await repository.GetListAsync();

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task Delete_OnSuccess()
    {
        var id = 2;
        //var expectedName = "Sieu Nhan";

        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "DeleteOnSuccess")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new UserRepository(context);

        var result = await repository.FindByIdAsync(id);

        repository.Delete(result);
        context.SaveChanges();

        var query = await repository.GetListAsync();

        Assert.Equal(1, query.Count());
    }
}
