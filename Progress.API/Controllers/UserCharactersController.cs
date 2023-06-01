using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Usecases.UserCharacters;
using Progress.Application.Usecases.UserCharacters.Add;
using Progress.Application.Usecases.UserCharacters.Delete;

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
        public async Task<ActionResult<IEnumerable<UserCharacterResponseDto>>> GetAsync([FromQuery] UserCharactersQuery query) => Ok(await mediator.Send(query));

        [HttpPost]
        public async Task<ActionResult<UserCharacterResponseDto>> PostAsync([FromBody] AddUserCharacterCommand query) => Ok(await mediator.Send(query));

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteUserCharacterCommand query) => Ok(await mediator.Send(query));
    }
}
