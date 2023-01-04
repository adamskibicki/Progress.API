using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Usecases.Trees.AddTestTree;

namespace Progress.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TreeController: ControllerBase
    {
        private readonly IMediator mediator;

        public TreeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost(Name = "AddTestTree")]
        public async Task<ActionResult<bool>> AddTestTreeAsync([FromQuery] AddTestTreeCommand command) => Ok(await mediator.Send(command));
    }
}