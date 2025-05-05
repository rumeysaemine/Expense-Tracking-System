namespace ExpenseTracking.Domain;

public class Expense
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = "EFT";                 // Kredi Kartı, Nakit vs.
    public string Location { get; set; } = null!;
    public string Description { get; set; }
    public DateTime ExpenseDate { get; set; }                          // Harcama tarihi
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;       // Talep tarihi
    public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending; // Pending, Approved, Rejected
    public string? RejectionReason { get; set; }
    
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }

    public User User { get; set; } = null!;
    public ExpenseCategory Category { get; set; } = null!;
    public ICollection<ExpenseDocument> Documents { get; set; } = new List<ExpenseDocument>();
}
