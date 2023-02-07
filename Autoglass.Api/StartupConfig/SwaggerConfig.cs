using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Autoglass.Api.StartupConfig
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApp",
                    Version = "v1",
                    Description = "WebApp",
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Luiz Blasechi",
                        Email = "renanluiz2241@gmail.com"
                    }
                });
                c.EnableAnnotations();
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp v1");
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
