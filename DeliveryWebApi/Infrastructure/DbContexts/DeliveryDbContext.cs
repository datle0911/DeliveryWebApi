using Microsoft.EntityFrameworkCore;
using DeliveryWebApi.Infrastructure.EntityTypeConfigurations;

namespace DeliveryWebApi.Infrastructure.DbContexts;

public class DeliveryDbContext : DbContext
{
#pragma warning disable CS8618
    public DeliveryDbContext(DbContextOptions options) : base(options)
    {
    }
#pragma warning disable CS8618

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }
}
