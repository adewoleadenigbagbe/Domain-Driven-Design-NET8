using App.Data.Contexts;
using App.Data.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Host.Configuration.ServiceModules
{
    public static class DbConnectionModule
    {
        public static void RegisterDbServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ReadAppContext, MySqlReadAppContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
            serviceCollection.AddDbContext<ReadWriteAppContext, MySqlReadWriteAppContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
        }
    }
}
