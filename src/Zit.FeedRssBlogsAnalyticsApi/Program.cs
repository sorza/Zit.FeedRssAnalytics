
using Microsoft.EntityFrameworkCore;
using Zit.FeedRssAnalytics.Domain.Repositories.AbstractRepository;
using Zit.FeedRssAnalytics.Infra.Data.ORM;
using Zit.FeedRssAnalytics.Infra.Repositories.ImplementationsRepository;
using Zit.FeedRssBlogsAnalyticsApi.Configurations.Automappers;
using Zit.FeedRssBlogsAnalyticsApi.Configurations.Extensions;

namespace Zit.FeedRssBlogsAnalyticsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerConfiguration();

            builder.Services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("ConnStr")));

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            builder.Services.AddScoped<IQueryRepository, QueryRepository>();
            builder.Services.AddScoped<IQueryADORepository, QueryADORepository>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();

                app.UseSwaggerConfiguration();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}