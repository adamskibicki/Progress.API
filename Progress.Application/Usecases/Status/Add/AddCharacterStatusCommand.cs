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
