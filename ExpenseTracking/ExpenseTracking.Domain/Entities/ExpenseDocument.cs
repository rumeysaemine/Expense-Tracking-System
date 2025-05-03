namespace ExpenseTracking.Domain;

public class ExpenseDocument
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; } = null!; 
    public string FileType { get; set; }
    
    public Guid ExpenseId { get; set; }
    
    public Expense Expense { get; set; } = null!;
}
