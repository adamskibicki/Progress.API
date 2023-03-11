using AutoMapper;
using FluentValidation;
using MediatR;
using Progress.Application.Common;
using Progress.Application.Usecases.Status;

namespace Progress.Application.Usecases.Categories
{
    public class AddNewCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; }
        public string DisplayColor { get; set; }
    }

    public class AddNewCategoryCommandValidator : AbstractValidator<AddNewCategoryCommand>
    {
        public AddNewCategoryCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x => x.DisplayColor).NotEmpty().IsColorString();
        }
    }

    public class AddNewCategoryCommandHandler : IRequestHandler<AddNewCategoryCommand, CategoryDto>
    {
        private readonly IMapper mapper;

        public AddNewCategoryCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<CategoryDto> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(mapper.Map<CategoryDto>(request));
        }
    }
}
