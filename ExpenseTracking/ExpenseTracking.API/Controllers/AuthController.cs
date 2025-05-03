using ExpenseTracking.Application;
using ExpenseTracking.Application.Features.Auth;
using ExpenseTracking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(IAppDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.Email == request.Email && u.PasswordHash == request.Password); // ⚠️ Gerçek projede şifre hash karşılaştırması yapılmalı

        if (user == null)
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