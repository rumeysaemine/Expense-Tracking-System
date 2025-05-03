using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public interface IExpenseRepository : IGenericRepository<Expense>
{
    Task<IEnumerable<Expense>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Expense>> GetPendingExpensesAsync();
    Task<IEnumerable<Expense>> GetApprovedExpensesAsync(DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<Expense>> GetRejectedExpensesAsync(Guid userId);
}