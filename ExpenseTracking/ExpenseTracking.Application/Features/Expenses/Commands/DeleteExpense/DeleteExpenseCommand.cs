using MediatR;

namespace ExpenseTracking.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}