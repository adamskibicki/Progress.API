using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence;

namespace Progress.Application.Tests.Usecases.Common
{
    internal static class Fixtures
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
    }
}
