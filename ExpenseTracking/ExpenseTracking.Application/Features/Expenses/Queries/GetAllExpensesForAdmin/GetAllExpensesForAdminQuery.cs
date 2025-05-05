using ExpenseTracking.Application.Features.Expenses.DTOs;
using MediatR;

namespace ExpenseTracking.Application.Features.Expenses.Queries.GetAllExpensesForAdmin;

public class GetAllExpensesForAdminQuery : IRequest<List<ExpenseDto>>
{
}