using AutoFixture;
using FluentValidation;
using Moq;
using Progress.Application.Persistence;
using Progress.Application.Persistence.Entities;
using Progress.Application.Security.Services;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.Categories.Get;
using Progress.Application.Usecases.Status.Get;
using Progress.Application.Usecases.UserCharacters;
using Progress.Application.Usecases.UserCharacters.Get;

namespace Progress.Application.Tests.Usecases.UserCategories.Get;

public class GetUserCategoriesQueryHandlerTests
{
    private readonly ApplicationDbContext dbContext;
    private readonly GetUserCategoriesQueryHandler handler;
    private readonly Fixture fixture;
    private readonly Mock<ICurrentUser> currentUserMock;

    public GetUserCategoriesQueryHandlerTests()
    {
        fixture = TestHelpersFactory.CreateFixture();
        dbContext = TestHelpersFactory.CreateApplicationDbContext();
        var mapper = TestHelpersFactory.CreateMapper();
        currentUserMock = new Mock<ICurrentUser>();
        handler = new GetUserCategoriesQueryHandler(dbContext, mapper.ConfigurationProvider, currentUserMock.Object,
            new List<IValidator<GetUserCategoriesQuery>>());
    }

    [Fact]
    public async Task Handle_ShouldReturnOnlyUserCharactersForCurrentUser_WhenCurrentUserIsLoggedIn()
    {
        // Arrange
        var user0 = new User();
        var user1 = new User();
        dbContext.AddRange(user0, user1);

        var categoryCreator = (User user) =>
            fixture.Build<Category>().Without(c => c.Skills).With(c => c.User, user).Create();

        var category0 = categoryCreator(user0);
        var category1 = categoryCreator(user0);
        var category2 = categoryCreator(user1);
        var category3 = categoryCreator(user1);
        dbContext.AddRange(category0, category1, category2, category3);

        await dbContext.SaveChangesAsync();

        currentUserMock.SetupGet(x => x.Id).Returns(user0.Id);

        var query = new GetUserCategoriesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsRight.Should().BeTrue();

        var dtos = result.Match(Right: enumerable => enumerable.ToArray(),
            Left: _ => Array.Empty<CategoryDto>());
        dtos.Count().Should().Be(2);
        dtos[0].Id.Should().Be(category0.Id);
        dtos[1].Id.Should().Be(category1.Id);
    }
}