using ExpenseTracking.Domain;

namespace ExpenseTracking.Infrastructure;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}