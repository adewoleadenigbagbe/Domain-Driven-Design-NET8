using App.Data.Contexts;
using App.Data.MySQL;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Infastructure.Refits;

namespace App.Host.Configuration.ServiceModules
{
    public static class RefitModule
    {
        private static readonly NameValueCollection _connectionStrings = ConfigurationManager.AppSettings;
        public static void RegisterRefitServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddRefitClient<ICountryApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri(_connectionStrings["CountryUrl"]));
        }
    }
}
