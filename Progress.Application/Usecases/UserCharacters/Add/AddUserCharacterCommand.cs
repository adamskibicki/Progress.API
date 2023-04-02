using AutoMapper;
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
    public class AddUserCharacterCommand : IRequest<UserCharacterDto>
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class AddUserCharacterCommandHandler : IRequestHandler<AddUserCharacterCommand, UserCharacterDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AddUserCharacterCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserCharacterDto> Handle(AddUserCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterStatus = new CharacterStatus
            {
                BasicInformation = new BasicInformation
                {
                    Name = request.Name,
                    Title= request.Title,
                },
                CreatedAt = DateTimeOffset.UtcNow
            };

            var userCharacter = new UserCharacter
            {
                CharacterStatuses = new List<CharacterStatus> { characterStatus }
            };

            dbContext.UserCharacters.Add(userCharacter);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserCharacterDto>(characterStatus);
        }
    }
}
