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

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MqttClientHelperOptions>(config.GetSection("MqttClientHelperOptions"));
builder.Services.AddSingleton<MqttClientHelper>();

builder.Services.AddSignalR();

builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<UnitOfWork>();

builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<RealtimeHub>("/realtimehub");

app.Run();
