using AutoMapper;
using FluentValidation;
using LanguageExt;
using MediatR;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Categories
{
    public class AddNewCategoryCommand : IRequest<Either<Failure, CategoryDto>>
    {
        public string Name { get; set; }
        public string DisplayColor { get; set; }
    }

    public class AddNewCategoryCommandValidator : AbstractValidator<AddNewCategoryCommand>
    {
        public AddNewCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DisplayColor).NotEmpty().IsColorString();
        }
    }

    public class AddNewCategoryCommandHandler : ValidationRequestHandler<AddNewCategoryCommand, CategoryDto>
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public AddNewCategoryCommandHandler(IMapper mapper, ApplicationDbContext dbContext, IEnumerable<IValidator<AddNewCategoryCommand>> validators) : base(validators)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        protected override async Task<Either<Failure, CategoryDto>> WrappedHandle(AddNewCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category> (request);

            dbContext.Add(category);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<CategoryDto>(category);
        }
    }
}
