using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progress.Application;
using Progress.Application.Quests.GetAllQuests;

namespace Progress.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuestsController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuestsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpGet(Name = "GetAllQuests")]
        public async Task<ActionResult<IEnumerable<QuestDto>>> GetAllQuestsAsync([FromQuery] GetAllQuestsQuery query) => Ok(await mediator.Send(query));

        [HttpGet(Name = "GetAllQuestsNonAuth")]
        public async Task<ActionResult<IEnumerable<QuestDto>>> GetAllQuestsNonAuthAsync([FromQuery] GetAllQuestsQuery query) => Ok(await mediator.Send(query));
    }
}