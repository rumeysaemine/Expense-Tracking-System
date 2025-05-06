using System.Security.Claims;
using ExpenseTracking.Application.Features;
using ExpenseTracking.Application.Features.Expenses.Commands.ApproveExpense;
using ExpenseTracking.Application.Features.Expenses.Commands.RejectExpense;
using ExpenseTracking.Application.Features.Expenses.Queries.GetAllExpenses;
using ExpenseTracking.Application.Features.Expenses.Queries.GetAllExpensesForAdmin;
using ExpenseTracking.Application.Features.Expenses.Queries.GetExpensesByStatus;
using ExpenseTracking.Application.Features.Users.Commands;
using ExpenseTracking.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Personel")]
    public async Task<IActionResult> Create([FromBody] CreateExpenseCommand command)
    {
        // JWT Token içinden UserId'yi çek
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized("User identity not found.");
        }

        // Command içine kullanıcıyı ekle
        command.UserId = Guid.Parse(userIdClaim.Value);

        // Command'ı MediatR ile işleyip sonucu al
        var createdExpenseId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = createdExpenseId }, createdExpenseId);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        // İleride GetExpenseByIdQuery kullanılarak doldurulabilir
        return Ok(new { Message = "GetById endpoint is not implemented yet", Id = id });
    }
    
    [HttpGet("my-expenses")]
    [Authorize(Roles = "Personel")]
    public async Task<IActionResult> GetMyExpenses()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized("User identity not found.");
        }

        var userId = Guid.Parse(userIdClaim.Value);
        var query = new GetAllExpensesQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }
    
    [HttpGet("my-expenses/by-status")]
    [Authorize(Roles = "Personel")]
    public async Task<IActionResult> GetMyExpensesByStatus([FromQuery] ExpenseStatus status)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim is null || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized("Geçersiz kullanıcı kimliği.");

        var query = new GetExpensesByStatusQuery(status, userId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllExpensesForAdmin()
    {
        var query = new GetAllExpensesForAdminQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPost("add-personel")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddPersonel([FromBody] AddUserByAdminCommand command)
    {
        var createdUserId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = createdUserId }, createdUserId);
    }
    
    [HttpPost("{id}/approve")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ApproveExpense(Guid id)
    {
        var result = await _mediator.Send(new ApproveExpenseCommand { ExpenseId = id });
        return result ? Ok("Onaylandı ve ödeme gönderildi.") : NotFound();
    }

    [HttpPost("{id}/reject")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RejectExpense(Guid id, [FromBody] string reason)
    {
        var result = await _mediator.Send(new RejectExpenseCommand { ExpenseId = id, Reason = reason });
        return result ? Ok("Masraf talebi reddedildi.") : NotFound();
    }
    
}