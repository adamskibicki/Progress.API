using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        public Guid CharacterStatusId { get; set; }

        public CharacterStatusRequestDto CharacterStatus { get; set; }
    }

    public class CharacterStatusRequestDto
    {
        public GeneralInformationRequestDto GeneralInformation { get; set; }
    }

    public class GeneralInformationRequestDto
    {
        public BasicInfoRequestDto BasicInfo { get; set; }
    }

    public class BasicInfoRequestDto
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
            var userCharacter = dbContext.CharacterStatuses
                .Include(cs => cs.UserCharacter)
                .First(cs => cs.Id == request.CharacterStatusId)
                .UserCharacter;

            var newCharacterStatus = mapper.Map<CharacterStatus>(request.CharacterStatus);
            newCharacterStatus.UserCharacter = userCharacter;
            newCharacterStatus.CreatedAt = DateTimeOffset.UtcNow;

            userCharacter.CharacterStatuses.Add(newCharacterStatus);

            await dbContext.CharacterStatuses.AddAsync(newCharacterStatus, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<StatusDto>(newCharacterStatus);
        }
    }
}
