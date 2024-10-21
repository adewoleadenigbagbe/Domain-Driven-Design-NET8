using App.Host.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Host.SystemWeb
{
    public class Startup
    {
        public static void Configure(IApplicationBuilder applicationBuilder, IServiceCollection services)
        {
            //Add services 
            services.AddControllers();
            //builder.Services.AddSwaggerGen();

            ServiceRegistration.Register(services);

            applicationBuilder.UseCors();

            //applicationBuilder.MapControllers();

            //app.UseRouting();
        }
    }
}
