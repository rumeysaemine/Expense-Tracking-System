using AutoMapper;
using ExpenseTracking.Application.Features.Expenses.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetExpensesByUserId;

public class GetExpensesByUserIdQueryHandler : IRequestHandler<GetExpensesByUserIdQuery, List<ExpenseDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetExpensesByUserIdQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExpenseDto>> Handle(GetExpensesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var expenses = await _context.Expenses
            .Include(e => e.Category)
            .Include(e => e.User)
            .Where(e => e.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<ExpenseDto>>(expenses);
    }
}