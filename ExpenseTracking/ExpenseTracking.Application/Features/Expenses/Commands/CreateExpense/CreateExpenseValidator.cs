using FluentValidation;

namespace ExpenseTracking.Application.Features.Expenses.Commands.CreateExpense;

public class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş olamaz.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Kategori seçilmelidir.");

        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Gelecek tarihli harcama yapılamaz.");
    }
}