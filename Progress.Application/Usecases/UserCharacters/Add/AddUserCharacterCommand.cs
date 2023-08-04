using AutoMapper;
using FluentValidation;
using LanguageExt;
using MediatR;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Security.Services;

namespace Progress.Application.Usecases.UserCharacters.Add
{
    public class AddUserCharacterCommand : IRequest<Either<Failure, UserCharacterResponseDto>>
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class AddUserCharacterCommandValidator : AbstractValidator<AddUserCharacterCommand>
    {
        public AddUserCharacterCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }

    public class
        AddUserCharacterCommandHandler : ValidationRequestHandler<AddUserCharacterCommand, UserCharacterResponseDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;

        public AddUserCharacterCommandHandler(ApplicationDbContext dbContext, IMapper mapper, ICurrentUser currentUser,
            IEnumerable<IValidator<AddUserCharacterCommand>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.currentUser = currentUser;
        }

        protected override async Task<Either<Failure, UserCharacterResponseDto>> WrappedHandle(
            AddUserCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterStatus = new CharacterStatus
            {
                BasicInformation = new BasicInformation
                {
                    Name = request.Name,
                    Title = request.Title,
                },
                CreatedAt = DateTimeOffset.UtcNow
            };

            var userCharacter = new UserCharacter
            {
                CharacterStatuses = new List<CharacterStatus> { characterStatus },
                UserId = currentUser.Id
            };

            dbContext.UserCharacters.Add(userCharacter);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserCharacterResponseDto>(userCharacter);
        }
    }
}