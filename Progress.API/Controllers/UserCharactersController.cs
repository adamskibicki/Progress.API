using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Usecases.UserCharacters;

namespace Progress.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserCharactersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserCharactersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetUserCharacters")]
        public async Task<ActionResult<IEnumerable<UserCharacterDto>>> GetUserCharactersAsync([FromQuery] UserCharactersQuery query) => Ok(await mediator.Send(query));
    }
}
