namespace ExpenseTracking.Application.Features.Expenses.DTOs;

public class ExpenseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ExpenseDate { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}