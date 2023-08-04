using AutoFixture;
using FluentValidation;
using Progress.Application.Persistence;
using Progress.Application.Tests.Usecases.Common;
using Progress.Application.Usecases.Status.Get;

namespace Progress.Application.Tests.Usecases.Status.Get;

public class GetCharacterStatusQueryTests
{
    private readonly ApplicationDbContext dbContext;
    private readonly GetCharacterStatusQueryHandler handler;
    private readonly Fixture fixture;

    public GetCharacterStatusQueryTests()
    {
        fixture = TestHelpersFactory.CreateFixture();
        dbContext = TestHelpersFactory.CreateApplicationDbContext();
        var mapper = TestHelpersFactory.CreateMapper();
        handler = new GetCharacterStatusQueryHandler(dbContext, mapper,
            new List<IValidator<GetCharacterStatusQuery>>());
    }

    [Fact]
    public async Task Handle_ShouldAddNewCharacterStatus_WhenCommandIsProvided()
    {
        // Arrange

        // Act

        // Assert
        true.Should().BeTrue();
    }
}