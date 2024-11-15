using App.Api.Controllers;
using App.Api.Converters;
using App.Api.Filters;
using App.Host.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace App.Host.SystemWeb
{
    public class Startup
    {
        public static void ConfigureApp(WebApplication app)
        {
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.MapControllers();
        }


        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ValidateModel>();
            services.AddControllers(opt =>
            {
                opt.Filters.Add<ValidateModel>();
            })
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.Converters.Add(new TrimConverter());
            })
            .AddApplicationPart(typeof(ProductController).Assembly);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddCors();

            ServiceRegistration.Register(services);
        }

        public static void ConfigureAppSettings(IConfigurationBuilder config, string[] args)
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .AddCommandLine(args).Build();
        }
    }
}
