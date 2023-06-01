using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace Progress.API.Common
{
    public static class ResultToActionResult
    {
        public static async Task<IActionResult> ToActionResult<TResult>(this Task<Result<TResult>> resultTask)
        {
            var result = await resultTask;

            return result
                .Match<IActionResult>(
                    r => r is Unit ? new OkResult() : new OkObjectResult(r),
                    r => new BadRequestObjectResult(r));
        }
    }
}
