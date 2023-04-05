using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Categories
{
    public class GetUserCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }

    public class GetUserCategoriesQueryHandler : IRequestHandler<GetUserCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfigurationProvider configurationProvider;

        public GetUserCategoriesQueryHandler(ApplicationDbContext dbContext, IConfigurationProvider configurationProvider)
        {
            this.dbContext = dbContext;
            this.configurationProvider = configurationProvider;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetUserCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Categories
                .ProjectTo<CategoryDto>(configurationProvider)
                .ToArrayAsync(cancellationToken: cancellationToken);
        }
    }
}
