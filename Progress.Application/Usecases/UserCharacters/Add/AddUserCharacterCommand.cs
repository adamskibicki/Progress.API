using AutoMapper;
using FluentValidation;
using MediatR;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.UserCharacters.Add
{
    public class AddUserCharacterCommand : IRequest<UserCharacterResponseDto>
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

    public class AddUserCharacterCommandHandler : IRequestHandler<AddUserCharacterCommand, UserCharacterResponseDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AddUserCharacterCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserCharacterResponseDto> Handle(AddUserCharacterCommand request, CancellationToken cancellationToken)
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
                CharacterStatuses = new List<CharacterStatus> { characterStatus }
            };

            dbContext.UserCharacters.Add(userCharacter);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserCharacterResponseDto>(userCharacter);
        }
    }
}
