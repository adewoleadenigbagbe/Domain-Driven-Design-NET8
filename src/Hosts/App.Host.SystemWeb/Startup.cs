using App.Api.Controllers;
using App.Api.Converters;
using App.Api.Filters;
using App.Host.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace App.Host.SystemWeb
{
    public class Startup
    {
        public static void Configure(WebApplication app)
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
    }
}
