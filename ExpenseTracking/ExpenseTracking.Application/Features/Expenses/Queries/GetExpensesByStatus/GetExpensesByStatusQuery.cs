using MediatR;
using ExpenseTracking.Application.Features.Expenses.DTOs;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetExpensesByStatus;

public class GetExpensesByStatusQuery : IRequest<List<ExpenseDto>>
{
    public ExpenseStatus Status { get; set; }

    public GetExpensesByStatusQuery(ExpenseStatus status)
    {
        Status = status;
    }
}