using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progress.API.Extensions;
using Progress.Application.Usecases.Users.Login;
using Progress.Application.Usecases.Users.Register;
using Progress.Application.Usecases.Users.ValidateToken;

namespace Progress.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class IdentityController : ControllerBase
{
    private readonly IMediator mediator;

    public IdentityController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost(Name = "RegisterUser")]
    public Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand command) =>
        mediator.Send(command).ToActionResult();
    
    [HttpPost(Name = "LoginUser")]
    public Task<IActionResult> LoginUserAsync([FromBody] LoginUserCommand command) =>
        mediator.Send(command).ToActionResult();
    
    [Authorize]
    [HttpPost(Name = "ValidateToken")]
    public Task<IActionResult> ValidateTokenAsync([FromBody] ValidateTokenCommand command) =>
        mediator.Send(command).ToActionResult();
}