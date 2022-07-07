namespace UnitTests;

public class CustomerRepositoryTest
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

        dbContext.Customers.AddRange(customers);
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

        var repository = new CustomerRepository(context);

        var result = await repository.GetAllAsync();

        Assert.Equal(4, result.Count());
    }

    [Fact]
    public async Task GetByName_OnSuccess_ReturnsCustomersList_HasCorrectFullName()
    {
        var name = "Chua He";

        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "ReturnsChuaHe")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new CustomerRepository(context);

        var result = await repository.GetByName(name);

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task FindByEmailAsync_OnSuccess_ReturnsSingleCustomer_HasCorrectEmail()
    {
        var email = "dat.lt@kyanon";
        var expectedName = "Le Thanh Dat";

        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "ReturnsSingleCustomerByEmail")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new CustomerRepository(context);

        var result = await repository.FindByEmailAsync(email);

        Assert.Equal(expectedName, result.CustomerFullName);
    }

    [Fact]
    public async Task FindByIdAsync_OnSuccess_ReturnsSingleCustomer_HasCorrectId()
    {
        var id = 3;
        var expectedName = "Sieu Nhan";

        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "ReturnsSingleCustomerById")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new CustomerRepository(context);

        var result = await repository.FindByIdAsync(id);

        Assert.Equal(expectedName, result.CustomerFullName);
    }

    [Fact]
    public async Task Add_OnSuccess()
    {
        var newCustomer = new Customer("MunMeow", "mundeptrai", "Le Thanh Mun", "12345678", "mun.meow@123");
        var expectedUserName = "MunMeow";

        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "AddOnSuccess")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new CustomerRepository(context);

        await repository.Add(newCustomer);
        context.SaveChanges();

        // check new customer
        var result = await repository.FindByIdAsync(5);

        Assert.Equal(expectedUserName, result.CustomerUserName);
    }

    [Fact]
    public async Task Delete_OnSuccess()
    {
        var id = 4;
        //var expectedName = "Sieu Nhan";

        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "DeleteOnSuccess")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new CustomerRepository(context);

        var result = await repository.FindByIdAsync(id);

        repository.Delete(result);
        context.SaveChanges();

        var query = await repository.GetAllAsync();

        Assert.Equal(3, query.Count());
    }
}
