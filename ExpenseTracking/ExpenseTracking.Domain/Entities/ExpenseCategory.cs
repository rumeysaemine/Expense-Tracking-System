namespace ExpenseTracking.Domain;

public class ExpenseCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
