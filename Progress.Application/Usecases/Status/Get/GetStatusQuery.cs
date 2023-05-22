using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.Status.Get
{
    public class GetStatusQuery : IRequest<StatusDto>
    {
        public Guid StatusId { get; set; }
    }

    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, StatusDto>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetStatusQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StatusDto> Handle(GetStatusQuery request, CancellationToken cancellationToken)
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