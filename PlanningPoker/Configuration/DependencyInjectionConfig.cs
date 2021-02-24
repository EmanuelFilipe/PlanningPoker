using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Data.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

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
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }

    }
}
