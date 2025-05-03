using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
{
    public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(c => c.Expenses)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId);
    }
}
