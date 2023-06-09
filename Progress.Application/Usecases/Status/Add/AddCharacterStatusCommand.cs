﻿using AutoMapper;
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

        private Category[] cachedUserCategories = Array.Empty<Category>();

        public AddCharacterStatusCommandHandler(ApplicationDbContext dbContext, IMapper mapper,
            IEnumerable<IValidator<AddCharacterStatusCommand>> validators) : base(validators)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task<Either<Failure, StatusDto>> WrappedHandle(AddCharacterStatusCommand request,
            CancellationToken cancellationToken)
        {
            await CacheUserCategories(cancellationToken);

            var newCharacterStatus = mapper.Map<CharacterStatus>(request.CharacterStatus);

            newCharacterStatus.CreatedAt = DateTimeOffset.UtcNow;

            var stats = request.CharacterStatus.GeneralInformation.Stats.Stats.Select(s =>
            (
                Entity: mapper.Map<Stat>(s),
                dtoId: s.Id
            )).ToArray();
            HandleUserCharacterRelation(request, newCharacterStatus);
            HandleResourcesStatsRelations(request, newCharacterStatus, stats);
            HandleClasses(request, newCharacterStatus, stats);

            await dbContext.CharacterStatuses.AddAsync(newCharacterStatus, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<StatusDto>(newCharacterStatus);
        }

        private async Task CacheUserCategories(CancellationToken cancellationToken)
        {
            cachedUserCategories = await dbContext.Categories.ToArrayAsync(cancellationToken: cancellationToken);
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

        private void HandleResourcesStatsRelations(AddCharacterStatusCommand request,
            CharacterStatus newCharacterStatus, (Stat Entity, Guid dtoId)[] stats)
        {
            var resources = request.CharacterStatus.GeneralInformation.Resources.Select(s => new
            {
                Entity = mapper.Map<Resource>(s),
                dtoBaseStatId = s.BaseStatId
            }).ToList();

            foreach (var resource in resources)
            {
                foreach (var stat in stats)
                {
                    if (resource.dtoBaseStatId is not null &&
                        resource.dtoBaseStatId == stat.dtoId)
                    {
                        resource.Entity.BaseStat = stat.Entity;
                    }
                }
            }

            newCharacterStatus.Stats = stats.Select(s => s.Entity).ToList();
            newCharacterStatus.Resources = resources.Select(r => r.Entity).ToList();
        }

        private void HandleClasses(AddCharacterStatusCommand request,
            CharacterStatus newCharacterStatus, (Stat Entity, Guid dtoId)[] stats)
        {
            var classes = request.CharacterStatus.Classes.Select(x => new
            {
                entity = mapper.Map<CharacterClass>(x),
                dto = x
            }).ToArray();

            foreach (var classWithSkillsDtos in classes)
            {
                HandleSkills(classWithSkillsDtos.entity, classWithSkillsDtos.dto, stats);
            }

            newCharacterStatus.CharacterClasses = classes.Select(x => x.entity).ToList();
        }

        private void HandleSkills(CharacterClass entity, CharacterClassRequestDto dto,
            (Stat Entity, Guid dtoId)[] stats)
        {
            var skills = dto.Skills.Select(x => new
            {
                entity = mapper.Map<Skill>(x),
                dto = x
            }).ToArray();

            foreach (var skill in skills)
            {
                HandleVariables(skill.entity, skill.dto, stats);
                HandleCategories(skill.entity, skill.dto);
            }

            entity.Skills = skills.Select(x => x.entity).ToList();
        }

        private void HandleCategories(Skill entity, SkillRequestDto dto)
        {
            var skillCategories = dto.CategoryIds
                .Select(categoryId => cachedUserCategories
                    .SingleOrDefault(x => x.Id == categoryId))
                .Where(dbCategory => dbCategory is not null)
                .ToList();

            entity.Categories = skillCategories;
        }

        private void HandleVariables(Skill entity, SkillRequestDto dto, (Stat Entity, Guid dtoId)[] stats)
        {
            var variables = dto.Variables.Select(x => new
            {
                entity = mapper.Map<SkillVariable>(x),
                dto = x
            }).ToArray();

            foreach (var variable in variables)
            {
                if (variable.dto.BaseSkillVariableId is not null)
                {
                    variable.entity.BaseSkillVariable =
                        variables.Single(x => x.dto.Id == variable.dto.BaseSkillVariableId).entity;
                }

                variable.entity.AffectedStats = stats
                    .Where(s => variable.dto.AffectedStatIds
                        .Contains(s.dtoId))
                    .Select(s => new SkillVariableStat()
                    {
                        Stat = s.Entity,
                        SkillVariable = variable.entity
                    })
                    .ToList();
            }

            entity.Variables = variables.Select(x => x.entity).ToList();
        }
    }
}