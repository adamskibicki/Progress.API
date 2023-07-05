using AutoFixture;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;

namespace Progress.Application.Tests.Usecases.Common;

internal static class ApplicationDbContextExtensions
{
    private static readonly Fixture Fixture = new();
    
    public static async Task<UserCharacter> CreateUserCharacterWithCharacterStatusThatHaveProvidedId(
        this ApplicationDbContext dbContext, Guid characterStatusId)
    {
        var characterStatus = Fixture.Build<CharacterStatus>()
            .With(cs => cs.Id, characterStatusId)
            .Without(cs => cs.UserCharacter)
            .Without(cs => cs.Resources)
            .Without(cs => cs.Stats)
            .Without(cs => cs.CharacterClasses)
            .Create();

        var userCharacterId = Guid.NewGuid();
        var userCharacter = Fixture.Build<UserCharacter>()
            .With(uc => uc.Id, userCharacterId)
            .With(uc => uc.CharacterStatuses, new List<CharacterStatus>() { characterStatus })
            .Create();

        dbContext.UserCharacters.Add(userCharacter);

        await dbContext.SaveChangesAsync();

        return userCharacter;
    }

    public static async Task<CharacterStatus> AddNewCharacterStatusToUserCharacter(this ApplicationDbContext dbContext,
        UserCharacter userCharacter, Guid characterStatusId)
    {
        userCharacter.CharacterStatuses ??= new List<CharacterStatus>();
        
        var characterStatus = Fixture.Build<CharacterStatus>()
            .With(cs => cs.Id, characterStatusId)
            .With(cs => cs.UserCharacter, userCharacter)
            .Without(cs => cs.Resources)
            .Without(cs => cs.Stats)
            .Without(cs => cs.CharacterClasses)
            .Create();

        dbContext.CharacterStatuses.Add(characterStatus);

        await dbContext.SaveChangesAsync();

        return characterStatus;
    }
    
    public static async Task<Category> AddNewCategory(this ApplicationDbContext dbContext, Guid categoryId)
    {
        var category = Fixture.Build<Category>()
            .With(cs => cs.Id, categoryId)
            .Without(cs => cs.Skills)
            .Create();

        dbContext.Categories.Add(category);

        await dbContext.SaveChangesAsync();

        return category;
    }
}