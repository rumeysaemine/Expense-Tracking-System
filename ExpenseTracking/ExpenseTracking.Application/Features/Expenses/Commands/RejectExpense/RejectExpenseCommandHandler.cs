using ExpenseTracking.Domain;
using MediatR;

namespace ExpenseTracking.Application.Features.Expenses.Commands.RejectExpense;

public class RejectExpenseCommandHandler : IRequestHandler<RejectExpenseCommand, bool>
{
    private readonly IAppDbContext _context;

    public RejectExpenseCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RejectExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses.FindAsync(new object[] { request.ExpenseId }, cancellationToken);
        if (expense == null) return false;

        expense.Status = ExpenseStatus.Rejected;
        expense.RejectionReason = request.Reason;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
