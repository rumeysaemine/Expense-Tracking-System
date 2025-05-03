namespace ExpenseTracking.Domain;

public class Payment
{
    public Guid Id { get; set; }
    public Guid ExpenseId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidAt { get; set; }
    public string IBAN { get; set; } = null!;
    public string PaymentMethod { get; set; } = "EFT";
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? TransactionReference { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid? ProcessedByUserId { get; set; }
    public User? ProcessedByUser { get; set; }

    public Expense Expense { get; set; } = null!;
}
