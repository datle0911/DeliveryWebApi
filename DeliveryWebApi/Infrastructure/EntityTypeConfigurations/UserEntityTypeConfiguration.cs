using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryWebApi.Infrastructure.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UserName).HasMaxLength(12);
        builder.Property(u => u.Password).HasMaxLength(12);
        builder.Property(u => u.FullName).HasMaxLength(12);
        builder.Property(u => u.PhoneNumber).HasMaxLength(12);
        builder.Property(u => u.Roles).IsRequired();
    }
}
