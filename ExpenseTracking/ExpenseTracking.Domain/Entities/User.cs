namespace ExpenseTracking.Domain;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserRole Role { get; set; } = UserRole.Personel; // Admin, Personel
    public string IBAN { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
