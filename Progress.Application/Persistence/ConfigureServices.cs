using Microsoft.Extensions.DependencyInjection;
using Progress.Application.Quests;

namespace Progress.Application.Persistence
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