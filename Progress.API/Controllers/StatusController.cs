using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Usecases.Status.Add;
using Progress.Application.Usecases.Status.Get;

namespace Progress.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterStatusController : ControllerBase
    {
        private readonly IMediator mediator;

        public CharacterStatusController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<StatusDto>> GetAsync([FromQuery] GetStatusQuery query) => Ok(await mediator.Send(query));

        [HttpPost]
        public async Task<ActionResult<StatusDto>> PostAsync([FromBody] AddCharacterStatusCommand command) => Ok(await mediator.Send(command));
    }
}
