namespace ExpenseTracking.Infrastructure;

public interface IFakePaymentService
{
    Task<string> ProcessPaymentAsync(string iban, decimal amount);
}
