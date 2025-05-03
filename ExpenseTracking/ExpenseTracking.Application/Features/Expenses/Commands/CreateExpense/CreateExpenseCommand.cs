using MediatR;

namespace ExpenseTracking.Application.Features;

public class CreateExpenseCommand : IRequest<Guid> // Geriye Expense Id dönecek
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; } // Giriş yapan kullanıcıdan alınabilir
}