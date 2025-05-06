using ExpenseTracking.Application;
using ExpenseTracking.Application.Features.Auth;
using ExpenseTracking.Domain;
using ExpenseTracking.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAppDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(IAppDbContext context, IJwtService jwtService, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
            return Unauthorized("E-posta veya şifre yanlış.");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
            return Unauthorized("E-posta veya şifre yanlış.");

        var token = _jwtService.GenerateToken(user.Id, user.Email, user.Role.ToString());

        var response = new LoginResponse
        {
            Token = token,
            Role = user.Role.ToString(),
            Email = user.Email
        };

        return Ok(response);
    }
}