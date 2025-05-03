using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.Role).IsRequired();
        builder.Property(u => u.IBAN).IsRequired().HasMaxLength(34); 

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.IsActive).IsRequired();

        builder.HasMany(u => u.Expenses)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
    }
}
