using App.Infastructure.AutoMapper;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Host.Configuration.ServiceModules
{
    public static class MediatRModule
    {
        public static void RegisterMediatRServices(this IServiceCollection serviceCollection)
        {
            var infastructureAssembly = AppDomain.CurrentDomain.Load("App.Infastructure");

            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(infastructureAssembly);
            });
        }

    }
}
