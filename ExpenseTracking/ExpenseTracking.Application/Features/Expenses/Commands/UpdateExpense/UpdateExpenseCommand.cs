using MediatR;
using System;

namespace ExpenseTracking.Application.Features;

public class UpdateExpenseCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ExpenseDate { get; set; }
    public Guid CategoryId { get; set; }
}