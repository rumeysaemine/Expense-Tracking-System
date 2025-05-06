using MediatR;

namespace ExpenseTracking.Application.Features.Expenses.Commands.RejectExpense;

public class RejectExpenseCommand : IRequest<bool>
{
    public Guid ExpenseId { get; set; }
    public string Reason { get; set; } = string.Empty;
}
