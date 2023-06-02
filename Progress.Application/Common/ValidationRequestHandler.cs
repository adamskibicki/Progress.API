using FluentValidation;
using LanguageExt;
using MediatR;

namespace Progress.Application.Common
{
    public abstract class ValidationRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, Either<Failure, TResponse>>
        where TRequest : IRequest<Either<Failure, TResponse>>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = Array.Empty<IValidator<TRequest>>();

        protected ValidationRequestHandler(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<Either<Failure, TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return WrappedHandle(request, cancellationToken);
            }

            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .ToArray();

            if (errors.Any())
            {
                return Task.FromResult(Either<Failure, TResponse>.Left(new Failure(new ValidationException(errors))));
            }

            return WrappedHandle(request, cancellationToken);
        }

        protected abstract Task<Either<Failure, TResponse>> WrappedHandle(TRequest request, CancellationToken cancellationToken);
    }
}
