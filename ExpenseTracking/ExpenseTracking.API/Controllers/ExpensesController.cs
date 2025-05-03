using System.Security.Claims;
using ExpenseTracking.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.API.Controllers;

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
}