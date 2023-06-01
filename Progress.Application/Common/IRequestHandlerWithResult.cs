using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;

namespace Progress.Application.Common
{
    public interface IRequestHandlerWithResult<TRequest> : IRequestHandler<TRequest, Result<Unit>> where TRequest : IRequest<Result<Unit>>
    {
    }

    public interface IRequestHandlerWithResult<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>> where TRequest : IRequest<Result<TResponse>>
    {
    }
}
