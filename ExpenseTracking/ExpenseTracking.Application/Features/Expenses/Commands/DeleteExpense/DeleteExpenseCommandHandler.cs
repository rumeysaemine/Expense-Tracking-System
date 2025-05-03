using ExpenseTracking.Application.Common.Exceptions;
using ExpenseTracking.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseTracking.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteExpenseCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (expense == null)
            {
                throw new NotFoundException(nameof(Expense), request.Id);
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}