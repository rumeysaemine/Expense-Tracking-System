using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(Guid userId);
    Task<Payment?> GetPaymentByExpenseIdAsync(Guid expenseId);
    Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);
}