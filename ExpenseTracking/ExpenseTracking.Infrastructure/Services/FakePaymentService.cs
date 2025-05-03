namespace ExpenseTracking.Infrastructure;

public class FakePaymentService : IFakePaymentService
{
    public async Task<string> ProcessPaymentAsync(string iban, decimal amount)
    {
        await Task.Delay(1000); 
        
        var reference = $"FAKE-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        return reference;
    }
}
