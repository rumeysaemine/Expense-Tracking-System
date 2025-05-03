using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(e => e.PaymentMethod).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Location).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.ExpenseDate).IsRequired();
        builder.Property(e => e.RequestDate).IsRequired();
        builder.Property(e => e.Status).IsRequired().HasMaxLength(20);
        builder.Property(e => e.RejectionReason).HasMaxLength(500);

        builder.HasOne(e => e.User)
            .WithMany(u => u.Expenses)
            .HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CategoryId);

        builder.HasMany(e => e.Documents)
            .WithOne(d => d.Expense)
            .HasForeignKey(d => d.ExpenseId);
    }
}
