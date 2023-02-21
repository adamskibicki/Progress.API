using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Usecases.Status;

namespace Progress.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StatusController : ControllerBase
    {
        private readonly IMediator mediator;

        public StatusController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetStatus")]
        public async Task<ActionResult<StatusDto>> GetStatusAsync([FromQuery] GetStatusQuery query) => Ok(await mediator.Send(query));
    }
}
