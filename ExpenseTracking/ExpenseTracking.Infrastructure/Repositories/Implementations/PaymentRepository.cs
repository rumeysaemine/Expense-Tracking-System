using ExpenseTracking.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Infrastructure;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Include(p => p.Expense)
            .Where(p => p.Expense.UserId == userId)
            .ToListAsync();
    }

    public async Task<Payment?> GetPaymentByExpenseIdAsync(Guid expenseId)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.ExpenseId == expenseId);
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(p => p.PaidAt >= startDate && p.PaidAt <= endDate)
            .Include(p => p.Expense)
            .Include(p => p.ProcessedByUser)
            .ToListAsync();
    }
}