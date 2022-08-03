namespace UnitTests;

public class ProductRepositoryTest
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

        var path = @"D:\HINH LE THANH DAT\ban-cao-mong.jpg";
        var image = System.IO.File.ReadAllBytes(path);

        var products = new List<Product>()
        {
            new Product("Tuna", "...", image, 12, EProductStatus.available),
            new Product("Table", "...", image, 22, EProductStatus.available),
            new Product("Tanu", "...", image, 15, EProductStatus.notavailable)
        };

        var orderDetails = new List<OrderDetail>()
        {
            new OrderDetail("a", 1, products.First(p => p.ProductName == "Tuna"), 2, 24),
            new OrderDetail("a", 2, products.FirstOrDefault(p => p.ProductName == "Table"), 1, 22)
        };

        var orders = new List<Order>()
        {
            new Order("a", 1, null, orderDetails, DateTime.Now, "69 Mai Chi Tho", "code 1", "robot A", 12, EOrderStatus.pending, EOrderTracking.packing)
        };

        dbContext.Customers.AddRange(customers);
        dbContext.Products.AddRange(products);
        dbContext.Orders.AddRange(orders);
        dbContext.SaveChanges();
    }

    [Fact]
    public async Task GetAllAsync_OnSuccess_ReturnsAllProducts()
    {
        var options = new DbContextOptionsBuilder<DeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllAsync_OnSuccess_ReturnsAllProducts")
            .Options;

        var context = new DeliveryDbContext(options);

        Seed(context);

        var repository = new ProductRepository(context);

        var result = await repository.GetAllAsync();

        Assert.Equal(3, result.Count());
    }

}
