using AutoMapper;
using ExpenseTracking.Application.Features.Expenses.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetExpensesByStatus;

public class GetExpensesByStatusQueryHandler : IRequestHandler<GetExpensesByStatusQuery, List<ExpenseDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetExpensesByStatusQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExpenseDto>> Handle(GetExpensesByStatusQuery request, CancellationToken cancellationToken)
    {
        var expenses = await _context.Expenses
            .Include(e => e.Category)
            .Include(e => e.User)
            .Where(e => e.Status == request.Status)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<ExpenseDto>>(expenses);
    }
}