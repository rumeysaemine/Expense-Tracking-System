namespace ExpenseTracking.Application;

public interface IJwtService
{
    string GenerateToken(Guid userId, string email, string role);
}