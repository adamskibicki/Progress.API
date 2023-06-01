using FluentValidation;

namespace Progress.Application.Common
{
    public class Failure
    {
        public Failure(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
