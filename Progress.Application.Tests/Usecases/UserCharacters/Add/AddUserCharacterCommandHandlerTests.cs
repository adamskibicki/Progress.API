using AutoFixture;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Moq;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Security.Services;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.UserCharacters.Add;

namespace Progress.Application.Tests.Usecases.UserCharacters.Add;

public class AddUserCharacterCommandHandlerTests
{
    private readonly ApplicationDbContext dbContext;
    private readonly AddUserCharacterCommandHandler handler;
    private readonly Fixture fixture;
    private readonly Mock<ICurrentUser> currentUserMock;

    public AddUserCharacterCommandHandlerTests()
    {
        fixture = TestHelpersFactory.CreateFixture();
        dbContext = TestHelpersFactory.CreateApplicationDbContext();
        var mapper = TestHelpersFactory.CreateMapper();
        currentUserMock = new Mock<ICurrentUser>();
        handler = new AddUserCharacterCommandHandler(dbContext, mapper, currentUserMock.Object,
            new List<IValidator<AddUserCharacterCommand>>());
    }

    [Fact]
    public async Task Handle_ShouldAddUserCharacterWithCurrentUserRelation_WhenUserIsLoggedIn()
    {
        // Arrange
        var user0 = new User();
        dbContext.AddRange(user0);
        await dbContext.SaveChangesAsync();
        var command = fixture.Create<AddUserCharacterCommand>();

        currentUserMock.SetupGet(x => x.Id).Returns(user0.Id);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsRight.Should().BeTrue();

        dbContext.UserCharacters
            .Include(userCharacter => userCharacter.User)
            .Single().User.Id
            .Should().Be(user0.Id);
    }
}