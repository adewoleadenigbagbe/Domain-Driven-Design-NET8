using App.Data.Contexts;
using App.Data.MySQL;
using Microsoft.Extensions.DependencyInjection;

namespace App.Host.Configuration
{
    public class ServiceRegistration
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ReadAppContext, MySqlReadAppContext>(
                contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
        }
    }
}
