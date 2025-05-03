using Microsoft.EntityFrameworkCore;
using ExpenseTracking.Domain; 
using ExpenseTracking.Application;

namespace ExpenseTracking.Infrastructure;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();
    public DbSet<ExpenseDocument> ExpenseDocuments => Set<ExpenseDocument>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        InitialDataSeeder.Seed(modelBuilder);
    }
}