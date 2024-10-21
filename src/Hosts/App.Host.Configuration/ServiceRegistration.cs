using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Collections.Specialized;
using System.Configuration;

using App.Host.Configuration.ServiceModules;

namespace App.Host.Configuration
{
    public static class ServiceRegistration
    {
        public static void Register(this IServiceCollection serviceCollection)
        {
            DbConnectionModule.RegisterDbServices(serviceCollection);
            MediatRModule.RegisterMediatRServices(serviceCollection);
            RefitModule.RegisterRefitServices(serviceCollection);
            AutoMapperModule.RegisterAutomapperServices(serviceCollection);
        }
    }
}
