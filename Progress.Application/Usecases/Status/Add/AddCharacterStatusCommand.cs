using AutoMapper;
using MediatR;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Status.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.Status.Add
{
    public class AddCharacterStatusCommand : IRequest<StatusDto>
    {
        public Guid UserCharacterId { get; set; }

        public CharacterStatusDto CharacterStatus { get; set; }
    }

    public class CharacterStatusDto
    {
        public GeneralInformationDto GeneralInformation { get; set; }
    }

    public class GeneralInformationDto
    {
        public BasicInfoDto BasicInfo { get; set; }
    }

    public class BasicInfoDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class AddCharacterStatusCommandHandler : IRequestHandler<AddCharacterStatusCommand, StatusDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AddCharacterStatusCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StatusDto> Handle(AddCharacterStatusCommand request, CancellationToken cancellationToken)
        {
            var userCharacter = dbContext.UserCharacters.First(uc => uc.Id == request.UserCharacterId);

            var newCharacterStatus = mapper.Map<CharacterStatus>(request.CharacterStatus);

            await dbContext.CharacterStatuses.AddAsync(newCharacterStatus, cancellationToken);

            userCharacter.CharacterStatuses.Add(newCharacterStatus);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<StatusDto>(newCharacterStatus);
        }
    }
}
