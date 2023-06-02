using FluentValidation;
using Progress.Application.Common;

namespace Progress.API.Extensions
{
    public static class FailuresHandlers
    {
        public static string HandleFailure(Failure failure)
        {
            return failure.Exception switch
            {
                ValidationException e => e.Message,
                _ => throw UnhandledFailureException(failure.Exception)
            };
        }

        private static Exception UnhandledFailureException<T>(T exception) where T : Exception
            => new($"Failure exception {exception?.GetType()} is not handled");
    }
}
