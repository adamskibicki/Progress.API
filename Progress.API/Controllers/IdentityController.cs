using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.API.Extensions;
using Progress.Application.Usecases.Users.Login;
using Progress.Application.Usecases.Users.Register;

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
}