using Microsoft.Extensions.DependencyInjection;

namespace Autoglass.Api.StartupConfig
{
    public static class DependencyInjectConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddMemoryCache();
        }
    }
}
