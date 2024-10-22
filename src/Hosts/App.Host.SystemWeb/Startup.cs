using App.Api.Controllers;
using App.Host.Configuration;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Host.SystemWeb
{
    public class Startup
    {
        public static void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors();

            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI();

            applicationBuilder.UseStaticFiles();
        }


        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            ServiceRegistration.Register(services);
        }

    }
}
