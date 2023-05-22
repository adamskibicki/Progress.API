using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Usecases.Categories;
using Progress.Application.Usecases.Status.Get;

namespace Progress.API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetUserCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetUserCategoriesAsync([FromQuery] GetUserCategoriesQuery query) => Ok(await mediator.Send(query));

        [HttpPost(Name = "AddNewCategory")]
        public async Task<ActionResult<CategoryDto>> AddNewCategoryAsync([FromBody] AddNewCategoryCommand command) => Ok(await mediator.Send(command));
    }
}
