using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryWebApi.Infrastructure.EntityTypeConfigurations;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(od => new { od.OrderId, od.ProductId });
        builder.Property(od => od.OrderId)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasOne(od => od.Product).WithMany().HasForeignKey(od => od.ProductId);

        builder.Property(od => od.Quantity).IsRequired();
        builder.Property(od => od.Total).IsRequired();
    }
}
