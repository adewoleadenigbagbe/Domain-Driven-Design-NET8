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
using Microsoft.Extensions.Configuration;

namespace App.Host.Configuration.ServiceModules
{
    public static class RefitModule
    {
        private static readonly IConfiguration _configuration;
        static RefitModule()
        {
            var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static void RegisterRefitServices(this IServiceCollection serviceCollection)
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            serviceCollection.AddRefitClient<ICountryApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri(appSettingsSection["CountryUrl"]!));
        }
    }
}
