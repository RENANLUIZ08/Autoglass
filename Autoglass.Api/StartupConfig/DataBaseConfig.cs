using App.RLB.Infra.Data.Context;
using Autoglass.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Api.StartupConfig
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var dataBase = configuration.GetSection("MyDb").Value;
            services.AddDbContext<MyDbContext>(opt => opt.UseInMemoryDatabase(dataBase));
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
