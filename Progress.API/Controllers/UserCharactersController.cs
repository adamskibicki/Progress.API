using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progress.API.Extensions;
using Progress.Application.Usecases.UserCharacters.Add;
using Progress.Application.Usecases.UserCharacters.Delete;
using Progress.Application.Usecases.UserCharacters.Get;

namespace Progress.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCharactersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserCharactersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] GetUserCharactersQuery query) =>
            mediator.Send(query).ToActionResult();

        [Authorize]
        [HttpPost]
        public Task<IActionResult> PostAsync([FromBody] AddUserCharacterCommand query) =>
            mediator.Send(query).ToActionResult();

        [Authorize]
        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteUserCharacterCommand command) =>
            mediator.Send(command).ToActionResult();
    }
}