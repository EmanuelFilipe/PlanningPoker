using Microsoft.Extensions.DependencyInjection;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Data.Repositories;

namespace PlanningPoker.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ICartaRepository, CartaRepository>();
            services.AddTransient<IHistoriaUsuarioRepository, HistoriaUsuarioRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();

            return services;
        }

    }
}
