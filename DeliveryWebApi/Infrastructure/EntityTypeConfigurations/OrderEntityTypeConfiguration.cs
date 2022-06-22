using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryWebApi.Infrastructure.EntityTypeConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.OrderId);
        builder.HasIndex(o => o.OrderId)
            .IsUnique();
        builder.Property(o => o.OrderId)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(o => o.Customer).WithMany().HasForeignKey(o => o.CustomerId);

        builder.HasMany(o => o.Details).WithOne().HasForeignKey(ob => ob.OrderId);

        builder.Property(o => o.OrderTimestamp).IsRequired();
        builder.Property(o => o.OrderAddress).HasMaxLength(50);
        builder.Property(o => o.OrderQrCode).HasMaxLength(50);
        builder.Property(o => o.OrderRobot).HasMaxLength(50);
        builder.Property(o => o.TotalPrice).IsRequired();
        builder.Property(o => o.OrderStatus).IsRequired();
        builder.Property(o => o.OrderTracking).IsRequired();
    }
}
