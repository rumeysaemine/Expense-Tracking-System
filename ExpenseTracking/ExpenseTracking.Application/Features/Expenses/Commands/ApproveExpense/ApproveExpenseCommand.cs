using MediatR;

namespace ExpenseTracking.Application.Features.Expenses.Commands.ApproveExpense;

public class ApproveExpenseCommand : IRequest<bool>
{
    public Guid ExpenseId { get; set; }
}
