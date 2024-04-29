using Microsoft.Extensions.DependencyInjection;
using HahaMedia.Application.Interfaces;
using HahaMedia.Infrastructure.Resources.Services;

namespace HahaMedia.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static void AddResourcesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITranslator, Translator>();
        }
    }
}
