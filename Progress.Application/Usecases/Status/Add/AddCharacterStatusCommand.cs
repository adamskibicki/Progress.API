using AutoMapper;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Usecases.Status.Add
{
    public class AddCharacterStatusCommand : IRequest<Either<Failure, StatusDto>>
    {
        public Guid CharacterStatusId { get; set; }

        public CharacterStatusRequestDto CharacterStatus { get; set; }
    }

    public class AddCharacterStatusCommandHandler : ValidationRequestHandler<AddCharacterStatusCommand, StatusDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AddCharacterStatusCommandHandler(ApplicationDbContext dbContext, IMapper mapper, IEnumerable<IValidator<AddCharacterStatusCommand>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task<Either<Failure, StatusDto>> WrappedHandle(AddCharacterStatusCommand request, CancellationToken cancellationToken)
        {

            var newCharacterStatus = mapper.Map<CharacterStatus>(request.CharacterStatus);

            newCharacterStatus.CreatedAt = DateTimeOffset.UtcNow;

            HandleUserCharacterRelation(request, newCharacterStatus);
            HandleResourcesStatsRelations(request, newCharacterStatus);

            await dbContext.CharacterStatuses.AddAsync(newCharacterStatus, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<StatusDto>(newCharacterStatus);
        }

        private void HandleUserCharacterRelation(AddCharacterStatusCommand request, CharacterStatus newCharacterStatus)
        {
            var userCharacter = dbContext.CharacterStatuses
                .Include(cs => cs.UserCharacter)
                .First(cs => cs.Id == request.CharacterStatusId)
                .UserCharacter;

            newCharacterStatus.UserCharacter = userCharacter;
            userCharacter.CharacterStatuses.Add(newCharacterStatus);
        }

        private void HandleResourcesStatsRelations(AddCharacterStatusCommand request, CharacterStatus newCharacterStatus)
        {
            var stats = request.CharacterStatus.GeneralInformation.Stats.Stats.Select(s => new
            {
                Entity = mapper.Map<Stat>(s),
                s.Id
            }).ToList();
            var resources = request.CharacterStatus.GeneralInformation.Resources.Select(s => new
            {
                Entity = mapper.Map<Resource>(s),
                s.BaseStatId
            }).ToList();

            foreach (var resource in resources)
            {
                foreach (var stat in stats)
                {
                    if (resource.BaseStatId == stat.Id && resource.BaseStatId is not null && stat.Id is not null)
                    {
                        resource.Entity.BaseStat = stat.Entity;
                    }
                }
            }

            newCharacterStatus.Stats = stats.Select(s => s.Entity).ToList();
            newCharacterStatus.Resources = resources.Select(r => r.Entity).ToList();
        }
    }
}
