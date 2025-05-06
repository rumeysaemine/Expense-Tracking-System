using ExpenseTracking.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Application.Features.Expenses.Commands.ApproveExpense;

public class ApproveExpenseCommandHandler : IRequestHandler<ApproveExpenseCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IFakeBankService _bankService;

    public ApproveExpenseCommandHandler(IAppDbContext context, IFakeBankService bankService)
    {
        _context = context;
        _bankService = bankService;
    }

    public async Task<bool> Handle(ApproveExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await _context.Expenses.Include(e => e.User)
            .FirstOrDefaultAsync(e => e.Id == request.ExpenseId, cancellationToken);

        if (expense == null) return false;

        expense.Status = ExpenseStatus.Approved;
        //expense.ApprovalDate = DateTime.UtcNow;

        // Ödeme simülasyonu (kullanıcının IBAN’ına ödeme gönder)
        await _bankService.SendMoneyAsync(expense.User.IBAN, expense.Amount);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public interface IFakeBankService
{
    Task SendMoneyAsync(string iban, decimal amount);
}

public class FakeBankService : IFakeBankService
{
    public Task SendMoneyAsync(string iban, decimal amount)
    {
        Console.WriteLine($"Banka ödeme simülasyonu: {iban} hesabına {amount} ₺ gönderildi.");
        return Task.CompletedTask;
    }
}

