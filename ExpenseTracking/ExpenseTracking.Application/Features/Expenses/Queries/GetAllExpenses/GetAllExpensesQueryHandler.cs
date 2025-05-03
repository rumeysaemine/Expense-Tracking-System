using AutoMapper;
using ExpenseTracking.Application.Features.Expenses.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllExpensesQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        var expenses = await _context.Expenses
            .Include(e => e.Category)
            .Include(e => e.User)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<ExpenseDto>>(expenses);
    }
}