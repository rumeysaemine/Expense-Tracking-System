using ExpenseTracking.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Infrastructure;

public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Expense>> GetByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Include(e => e.Category)
            .Include(e => e.Documents)
            .Where(e => e.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Expense>> GetPendingExpensesAsync()
    {
        return await _dbSet
            .Where(e => e.Status == ExpenseStatus.Pending)
            .Include(e => e.User)
            .Include(e => e.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Expense>> GetApprovedExpensesAsync(DateTime? startDate = null, DateTime? endDate = null)
    {
        var query = _dbSet.AsQueryable();

        query = query.Where(e => e.Status == ExpenseStatus.Approved);

        if (startDate.HasValue)
            query = query.Where(e => e.ExpenseDate >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(e => e.ExpenseDate <= endDate.Value);

        return await query
            .Include(e => e.User)
            .Include(e => e.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Expense>> GetRejectedExpensesAsync(Guid userId)
    {
        return await _dbSet
            .Where(e => e.UserId == userId && e.Status == ExpenseStatus.Rejected)
            .ToListAsync();
    }
}