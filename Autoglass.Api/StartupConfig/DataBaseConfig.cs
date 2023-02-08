using Autoglass.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autoglass.Api.StartupConfig
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("MyDb");
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlite(connection));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
