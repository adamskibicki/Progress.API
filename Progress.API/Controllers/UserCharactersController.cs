using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.API.Extensions;
using Progress.Application.Usecases.UserCharacters;
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

        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] UserCharactersQuery query) => mediator.Send(query).ToActionResult();

        [HttpPost]
        public Task<IActionResult> PostAsync([FromBody] AddUserCharacterCommand query) => mediator.Send(query).ToActionResult();

        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteUserCharacterCommand command) => mediator.Send(command).ToActionResult();
    }
}