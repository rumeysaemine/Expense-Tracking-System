using MediatR;
using ExpenseTracking.Application.Features.Expenses.DTOs;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetExpensesByUserId;

public class GetExpensesByUserIdQuery : IRequest<List<ExpenseDto>>
{
    public Guid UserId { get; set; }

    public GetExpensesByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}