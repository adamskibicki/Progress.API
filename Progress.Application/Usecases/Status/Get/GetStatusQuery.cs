using AutoMapper;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Common;
using Progress.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.Status.Get
{
    public class GetCharacterStatusQuery : IRequest<Either<Failure, StatusDto>>
    {
        public Guid StatusId { get; set; }
    }

    public class GetStatusQueryHandler : ValidationRequestHandler<GetCharacterStatusQuery, StatusDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetStatusQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IEnumerable<IValidator<GetCharacterStatusQuery>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task<Either<Failure, StatusDto>> WrappedHandle(GetCharacterStatusQuery request, CancellationToken cancellationToken)
        {
            var dbStatus = await dbContext.CharacterStatuses
                .Include(cs => cs.Resources)
                .Include(cs => cs.Stats)
                .Include(cs => cs.CharacterClasses)
                .ThenInclude(cc => cc.ClassModifiers)
                .ThenInclude(cm => cm.Category)
                .Include(cs => cs.CharacterClasses)
                .ThenInclude(cc => cc.Skills)
                .ThenInclude(s => s.Categories)
                .Include(cs => cs.CharacterClasses)
                .ThenInclude(cc => cc.Skills)
                .ThenInclude(s => s.TierDescriptions)
                .Include(cs => cs.CharacterClasses)
                .ThenInclude(cc => cc.Skills)
                .ThenInclude(s => s.Variables)
                .ThenInclude(v => v.AffectedStats)
                .AsSplitQuery()
                .SingleAsync(cs => cs.Id == request.StatusId, cancellationToken: cancellationToken);

            return mapper.Map<StatusDto>(dbStatus);
        }
    }
}