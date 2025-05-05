using AutoMapper;
using ExpenseTracking.Domain;
using MediatR;

namespace ExpenseTracking.Application.Features.Expenses.Commands.CreateExpense;

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateExpenseCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = _mapper.Map<Expense>(request);

        expense.Id = Guid.NewGuid();
        expense.UserId = request.UserId; 
        expense.RequestDate = DateTime.UtcNow;

        await _context.Expenses.AddAsync(expense, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return expense.Id;
    }
}