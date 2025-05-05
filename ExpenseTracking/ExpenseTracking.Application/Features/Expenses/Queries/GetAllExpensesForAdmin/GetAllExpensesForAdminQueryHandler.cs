using AutoMapper;
using ExpenseTracking.Application.Features.Expenses.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetAllExpensesForAdmin;

public class GetAllExpensesForAdminQueryHandler : IRequestHandler<GetAllExpensesForAdminQuery, List<ExpenseDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllExpensesForAdminQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExpenseDto>> Handle(GetAllExpensesForAdminQuery request, CancellationToken cancellationToken)
    {
        var expenses = await _context.Expenses
            .Include(e => e.Category)
            .Include(e => e.User)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<ExpenseDto>>(expenses);
    }
}