using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progress.API.Extensions;
using Progress.Application.Usecases.Status.Add;
using Progress.Application.Usecases.Status.Delete;
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

        [Authorize]
        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] GetCharacterStatusQuery query) =>
            mediator.Send(query).ToActionResult();

        [Authorize]
        [HttpPost]
        public Task<IActionResult> PostAsync([FromBody] AddCharacterStatusCommand command) =>
            mediator.Send(command).ToActionResult();

        [Authorize]
        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteCharacterStatusCommand command) =>
            mediator.Send(command).ToActionResult();
    }
}