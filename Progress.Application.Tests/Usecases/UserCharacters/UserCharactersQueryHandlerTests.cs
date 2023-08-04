using AutoFixture;
using FluentValidation;
using LanguageExt;
using Moq;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Security.Services;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.UserCharacters;
using Progress.Application.Usecases.UserCharacters.Get;

namespace Progress.Application.Tests.Usecases.UserCharacters;

public class UserCharactersQueryHandlerTests
{
    private readonly ApplicationDbContext dbContext;
    private readonly UserCharactersQueryHandler handler;
    private readonly Fixture fixture;
    private readonly Mock<ICurrentUser> currentUserMock;

    public UserCharactersQueryHandlerTests()
    {
        fixture = TestHelpersFactory.CreateFixture();
        dbContext = TestHelpersFactory.CreateApplicationDbContext();
        var mapper = TestHelpersFactory.CreateMapper();
        currentUserMock = new Mock<ICurrentUser>();
        handler = new UserCharactersQueryHandler(dbContext, mapper, currentUserMock.Object,
            new List<IValidator<UserCharactersQuery>>());
    }

    [Fact]
    public async Task Handle_ShouldReturnOnlyUserCharactersForCurrentUser_WhenCurrentUserIsLoggedIn()
    {
        // Arrange
        var user0 = new User();
        var user1 = new User();
        dbContext.AddRange(user0, user1);

        var userCharacter0 = new UserCharacter
        {
            User = user0
        };
        var userCharacter1 = new UserCharacter
        {
            User = user1
        };
        dbContext.AddRange(userCharacter0, userCharacter1);

        await dbContext.SaveChangesAsync();

        currentUserMock.SetupGet(x => x.Id).Returns(user0.Id);

        var query = new UserCharactersQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsRight.Should().BeTrue();
        
        var dtos = result.Match(Right: enumerable => enumerable.ToArray(),
            Left: _ => Array.Empty<UserCharacterResponseDto>());
        dtos.Single().Id.Should().Be(userCharacter0.Id);
    }
}