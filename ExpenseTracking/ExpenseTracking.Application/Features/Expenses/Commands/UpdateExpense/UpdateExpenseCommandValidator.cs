using FluentValidation;

namespace ExpenseTracking.Application.Features.Expenses.Commands.UpdateExpense;

public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.ExpenseDate).LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}