using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.PaidAt)
            .IsRequired();

        builder.Property(p => p.IBAN)
            .IsRequired()
            .HasMaxLength(34);

        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue("EFT");

        builder.Property(p => p.Status)
            .IsRequired()
            .HasDefaultValue(PaymentStatus.Pending) 
            .HasSentinel(PaymentStatus.Pending);

        builder.Property(p => p.TransactionReference)
            .HasMaxLength(100);

        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("NOW()");

        builder.HasOne(p => p.Expense)
            .WithOne()
            .HasForeignKey<Payment>(p => p.ExpenseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.ProcessedByUser)
            .WithMany()
            .HasForeignKey(p => p.ProcessedByUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}