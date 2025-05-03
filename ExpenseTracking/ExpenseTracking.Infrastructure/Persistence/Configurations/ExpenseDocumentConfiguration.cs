using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public class ExpenseDocumentConfiguration : IEntityTypeConfiguration<ExpenseDocument>
{
    public void Configure(EntityTypeBuilder<ExpenseDocument> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FileName).IsRequired().HasMaxLength(255);
        builder.Property(d => d.FilePath).IsRequired();
        builder.Property(d => d.FileType).IsRequired().HasMaxLength(50);

        builder.HasOne(d => d.Expense)
            .WithMany(e => e.Documents)
            .HasForeignKey(d => d.ExpenseId);
    }
}
