using AutoFixture;
using FluentValidation;
using Moq;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Security.Services;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.UserCharacters.Delete;

namespace Progress.Application.Tests.Usecases.UserCharacters.Delete;

public class DeleteUserCharacterCommandHandlerTests
{
    private readonly ApplicationDbContext dbContext;
    private readonly DeleteUserCharacterCommandHandler handler;
    private readonly Fixture fixture;
    private readonly Mock<ICurrentUser> currentUserMock;

    public DeleteUserCharacterCommandHandlerTests()
    {
        fixture = TestHelpersFactory.CreateFixture();
        dbContext = TestHelpersFactory.CreateApplicationDbContext();
        currentUserMock = new Mock<ICurrentUser>();
        handler = new DeleteUserCharacterCommandHandler(dbContext, currentUserMock.Object,
            new List<IValidator<DeleteUserCharacterCommand>>());
    }

    [Fact]
    public async Task Handle_ShouldDeleteUserCharacterForUser_WhenUserIsLoggedIn()
    {
        // Arrange
        var user0 = new User();
        dbContext.AddRange(user0);
        var userCharacterId = Guid.NewGuid();
        dbContext.UserCharacters.Add(new UserCharacter()
        {
            Id = userCharacterId,
            User = user0
        });

        await dbContext.SaveChangesAsync();
        var command = new DeleteUserCharacterCommand() { Id = userCharacterId };

        currentUserMock.SetupGet(x => x.Id).Returns(user0.Id);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsRight.Should().BeTrue();

        dbContext.UserCharacters.Count().Should().Be(0);
    }

    [Fact]
    public async Task Handle_ShouldNotSucceedWhenUserTriesToDeleteUserCharacterNotInRelationWithHim_WhenUserIsLoggedIn()
    {
        // Arrange
        var user0 = new User();
        var user1 = new User();
        dbContext.AddRange(user0, user1);
        var userCharacterId = Guid.NewGuid();
        dbContext.UserCharacters.Add(new UserCharacter()
        {
            Id = userCharacterId,
            User = user0
        });

        await dbContext.SaveChangesAsync();
        var command = new DeleteUserCharacterCommand() { Id = userCharacterId };

        currentUserMock.SetupGet(x => x.Id).Returns(user1.Id);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        result.IsLeft.Should().BeTrue();
    }
}