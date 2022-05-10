using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryWebApi.Infrastructure.EntityTypeConfigurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.CustomerId);
        builder.Property(c => c.CustomerId).ValueGeneratedOnAdd();

        builder.Property(c => c.CustomerUserName).HasMaxLength(12);
        builder.Property(c => c.CustomerPassword).HasMaxLength(30);
        builder.Property(c => c.CustomerFullName).HasMaxLength(50);
        builder.Property(c => c.CustomerPhoneNumber).HasMaxLength(12);
        builder.Property(c => c.CustomerEmail).HasMaxLength(50);
    }
}
