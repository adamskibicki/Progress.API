using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence;
using Progress.Application.Usecases.Status.Add;

namespace Progress.Application.Tests.Usecases.Common
{
    internal static class TestHelpersFactory
    {
        public static ApplicationDbContext CreateApplicationDbContext()
        {
            var dbName = typeof(ApplicationDbContext) + "_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ApplicationDbContext(options);
        }

        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());

            return new Mapper(configuration);
        }

        public static Fixture CreateFixture()
        {
            var fixture = new Fixture();

            fixture.Customize<SkillVariableRequestDto>(x => x
                .With(sv => sv.BaseSkillVariableId, () => null));

            return fixture;
        }
    }
}