using MediatR;
using Progress.Application.Usecases.Status;

namespace Progress.Application.Usecases.Categories
{
    public class GetUserCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }

    public class GetUserCategoriesQueryHandler : IRequestHandler<GetUserCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public Task<IEnumerable<CategoryDto>> Handle(GetUserCategoriesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(typeof(CategoriesCollection).GetProperties().Select(p => p.GetValue(null) as CategoryDto));
        }
    }
}
