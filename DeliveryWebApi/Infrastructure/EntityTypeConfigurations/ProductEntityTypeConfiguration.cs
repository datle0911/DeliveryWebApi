using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryWebApi.Infrastructure.EntityTypeConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);
        builder.Property(p => p.ProductId)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ProductName).HasMaxLength(50);
        builder.Property(p => p.Description).HasMaxLength(50);
        builder.Property(p => p.ProductImage).IsRequired();
        builder.Property(p => p.ProductPrice).IsRequired();
        builder.Property(p => p.ProductStatus).IsRequired();
    }
}
