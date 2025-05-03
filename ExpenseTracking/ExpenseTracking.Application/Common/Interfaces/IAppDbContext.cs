using ExpenseTracking.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<Expense> Expenses { get; }
    DbSet<ExpenseCategory> ExpenseCategories { get; }
    DbSet<ExpenseDocument> ExpenseDocuments { get; }
    DbSet<Payment> Payments { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}