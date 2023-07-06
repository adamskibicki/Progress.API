using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progress.API.Extensions;
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

        [Authorize]
        [HttpGet(Name = "GetUserCategories")]
        public Task<IActionResult> GetUserCategoriesAsync([FromQuery] GetUserCategoriesQuery query) =>
            mediator.Send(query).ToActionResult();
        
        [Authorize]
        [HttpPost(Name = "AddNewCategory")]
        public Task<IActionResult> AddNewCategoryAsync([FromBody] AddNewCategoryCommand command) =>
            mediator.Send(command).ToActionResult();
    }
}