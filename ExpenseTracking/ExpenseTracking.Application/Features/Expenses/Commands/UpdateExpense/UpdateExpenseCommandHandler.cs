using AutoMapper;
using ExpenseTracking.Application.Common.Exceptions;
using ExpenseTracking.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application.Features.Expenses.Commands.UpdateExpense;

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateExpenseCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (expense == null)
        {
            throw new NotFoundException(nameof(Expense), request.Id);
        }

        _mapper.Map(request, expense);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}