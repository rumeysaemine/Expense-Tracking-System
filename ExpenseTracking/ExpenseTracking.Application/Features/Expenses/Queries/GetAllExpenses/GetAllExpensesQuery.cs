using MediatR;
using ExpenseTracking.Application.Features.Expenses.DTOs;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesQuery : IRequest<List<ExpenseDto>>
{
}