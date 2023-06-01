using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Categories
{
    public class GetUserCategoriesQuery : IRequest<Either<Failure, IEnumerable<CategoryDto>>>
    {
    }

    public class GetUserCategoriesQueryHandler : ValidationRequestHandler<GetUserCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfigurationProvider configurationProvider;

        public GetUserCategoriesQueryHandler(ApplicationDbContext dbContext, IConfigurationProvider configurationProvider, IEnumerable<IValidator<GetUserCategoriesQuery>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.configurationProvider = configurationProvider;
        }

        protected override async Task<Either<Failure, IEnumerable<CategoryDto>>> WrappedHandle(GetUserCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Categories
                .ProjectTo<CategoryDto>(configurationProvider)
                .ToArrayAsync(cancellationToken: cancellationToken);
        }
    }
}
