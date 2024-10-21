using App.Api.Controllers;
using App.Host.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Host.SystemWeb
{
    public class WebApp
    {
        public static void Configure(IApplicationBuilder applicationBuilder, IServiceCollection services)
        {
            //Add services 
            services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);

            services.AddEndpointsApiExplorer();

            //builder.Services.AddSwaggerGen();

            ServiceRegistration.Register(services);

            applicationBuilder.UseCors();

            //applicationBuilder.MapControllers();

        }
    }
}
