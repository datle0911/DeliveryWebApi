namespace UnitTests;
public class CustomerControllerTest
{
    private readonly Mock<DeliveryDbContext> _dbContext;
    private readonly Mock<CustomerRepository> _customerRepo;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<CustomerService> _customerService;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IHubContext<RealtimeHub>> _realtimeHub;

    private void Seed(DeliveryDbContext dbContext)
    {
        var customers = new List<Customer>()
        {
            new Customer(1, "datleqn", "datle123", "Le Thanh Dat", "09991199", "dat.lt@kyanon"),
            new Customer(2, "datlezzz", "datle123", "Chua He", "0123456", "dat.lt@kyanon"),
            new Customer(3, "datleqn123", "datle123", "Sieu Nhan", "6543210", "dat.lt@kyanon"),
            new Customer(4, "chuahezz", "datle123", "Chua He", "9999999", "dat.lt@kyanon"),

        };

        dbContext.Customers.AddRange(customers);
        dbContext.SaveChanges();
    }

    public CustomerControllerTest()
    {
        _dbContext = new Mock<DeliveryDbContext>();
        _customerRepo = new Mock<CustomerRepository>();
        _unitOfWork = new Mock<UnitOfWork>();
        _customerService = new Mock<CustomerService>();
        _mapper = new Mock<IMapper>();
        _realtimeHub = new Mock<IHubContext<RealtimeHub>>();
    }

    [Fact]
    public async Task GetAllAsync_OnSuccess_ReturnsStatusCode200()
    {
        var dbContext = new Mock<DeliveryDbContext>();
        var customerRepo = new Mock<CustomerRepository>(dbContext.Object);
        var customerService = new CustomerService(customerRepo.Object, _unitOfWork.Object);
        var sut = new CustomersController(customerService, _mapper.Object, _realtimeHub.Object);
        var result = (OkObjectResult)await sut.GetAllAsync();

        Assert.True(result.StatusCode == 200);
    }

}