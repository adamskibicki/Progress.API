using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Progress.Application.Common;

namespace Progress.API.Extensions
{
    using static FailuresHandlers;

    public static class EitherToActionResult
    {
        public static Task<IActionResult> ToActionResult<TResult>(this Task<Either<Failure, TResult>> either) =>
            either
                .ToAsync()
                .MapLeft(HandleFailure)
                .Match<IActionResult>(
                    result => result is Unit ? new OkResult() : new OkObjectResult(result),
                    failureMessage => new BadRequestObjectResult(failureMessage));
    }
}
