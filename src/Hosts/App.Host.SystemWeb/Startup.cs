using App.Api.Controllers;
using App.Api.Filters;
using App.Host.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        }


        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                opt.Filters.Add<ValidateModel>();
            }).AddApplicationPart(typeof(ProductController).Assembly);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            ServiceRegistration.Register(services);
        }
    }
}
