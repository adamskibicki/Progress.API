using Microsoft.Extensions.DependencyInjection;
using Progress.Application.Quests;

namespace Progress.Infrastructure.Persistence.Database
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestRepository, DummyQuestRepository>();

            return services;
        }
    }
}