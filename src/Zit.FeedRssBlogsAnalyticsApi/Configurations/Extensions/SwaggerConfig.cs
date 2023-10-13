using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Zit.FeedRssBlogsAnalyticsApi.Configurations.Extensions
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Web Scraping com Asp Net Core 7 & Angular 15",
                    Description = "Esta API serve recursos para consumo Feed RSS Web Scraping",
                    Contact = new OpenApiContact() {Name = "Alexandre Z Durães", Email = "alexandre.sorza@outlook.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("http://opensource.org/licenses/MIT") },
                    TermsOfService = new Uri("https://cooperchip.com.br")
                });

                var xmfFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmfFileName));
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zit | Web Scraping - v1");
            });

            return app;
        }
    }
}
