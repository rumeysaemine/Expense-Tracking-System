using MediatR;
using System.Text.Json.Serialization;

namespace ExpenseTracking.Application.Features;

public class CreateExpenseCommand : IRequest<Guid> // Geriye Expense Id dönecek
{
    public string Title { get; set; } = default!;
    public decimal Amount { get; set; }
    public string Description { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = default!;
    
    [JsonIgnore]
    public Guid UserId { get; set; } // Giriş yapan kullanıcıdan alınabilir
}