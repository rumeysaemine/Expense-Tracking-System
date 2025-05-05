using ExpenseTracking.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracking.Application.Features.Users.Commands;

public class AddUserByAdminCommandHandler : IRequestHandler<AddUserByAdminCommand, Guid>
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AddUserByAdminCommandHandler(IAppDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(AddUserByAdminCommand request, CancellationToken cancellationToken)
    {
        if (!Enum.TryParse<UserRole>(request.Role, true, out var parsedRole))
        {
            throw new ArgumentException("Invalid role specified.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = parsedRole,
            IBAN = request.IBAN
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
