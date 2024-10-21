using App.Infastructure.AutoMapper;
using App.Infastructure.Refits;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Host.Configuration.ServiceModules
{
    public static class AutoMapperModule
    {
        public static void RegisterAutomapperServices(this IServiceCollection serviceCollection)
        {
            var profilesAssembly = Assembly.GetAssembly(typeof(ProductProfile));
            var profiles = profilesAssembly?.GetTypes()?.Where(x => typeof(Profile).IsAssignableFrom(x)).Select(x =>
            {
                var profile  = (Profile)Activator.CreateInstance(x);
                return profile;
            }) ?? Enumerable.Empty<Profile>(); ;

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfiles(profiles);
            });

            var mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
