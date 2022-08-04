using DeliveryWebApi.Hubs;
using DeliveryWebApi.Infrastructure.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<DeliveryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer"));
});

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    }
));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Services lifetime
builder.Services.Configure<MqttClientHelperOptions>(config.GetSection("MqttClientHelperOptions"));
builder.Services.AddSingleton<MqttClientHelper>();

builder.Services.AddSignalR().AddAzureSignalR(config.GetConnectionString("SignalRConnection"));

builder.Services.AddScoped<IIdentityHelper, IdentityHelperService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapHub<RealtimeHub>("/realtimehub");

app.UseAzureSignalR(routes =>
{
    routes.MapHub<RealtimeHub>("/realtimehub");
});

app.Run();
