using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Security.Services;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Categories.Get
{
    public class GetUserCategoriesQuery : IRequest<Either<Failure, IEnumerable<CategoryDto>>>
    {
    }

    public class
        GetUserCategoriesQueryHandler : ValidationRequestHandler<GetUserCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfigurationProvider configurationProvider;
        private readonly ICurrentUser currentUser;

        public GetUserCategoriesQueryHandler(ApplicationDbContext dbContext,
            IConfigurationProvider configurationProvider,
            ICurrentUser currentUser,
            IEnumerable<IValidator<GetUserCategoriesQuery>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.configurationProvider = configurationProvider;
            this.currentUser = currentUser;
        }

        protected override async Task<Either<Failure, IEnumerable<CategoryDto>>> WrappedHandle(
            GetUserCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Categories
                .Where(c => c.UserId == currentUser.Id)
                .ProjectTo<CategoryDto>(configurationProvider)
                .ToArrayAsync(cancellationToken: cancellationToken);
        }
    }
}