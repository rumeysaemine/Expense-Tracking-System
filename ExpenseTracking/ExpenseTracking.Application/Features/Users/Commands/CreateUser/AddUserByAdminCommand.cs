using MediatR;

namespace ExpenseTracking.Application.Features.Users.Commands;

public class AddUserByAdminCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!; // şifreyi hashleyeceğiz
    public string Role { get; set; } = "Personel"; // varsayılan olarak personel
    public string IBAN { get; set; } = default!;
}