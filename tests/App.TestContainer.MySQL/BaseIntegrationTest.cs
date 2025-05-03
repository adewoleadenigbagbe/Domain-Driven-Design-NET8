using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Xunit;

namespace App.TestContainer.MySQL
{
    public class BaseIntegrationTest : IClassFixture<IntegrationWebTestFactory>
    {
        protected readonly IServiceScope _scope;
        protected readonly ReadAppContext _readAppContext;
        protected readonly ReadWriteAppContext _readWriteAppContext;


        public BaseIntegrationTest(IntegrationWebTestFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _readAppContext = _scope.ServiceProvider.GetService<ReadAppContext>();
            _readWriteAppContext = _scope.ServiceProvider.GetService<ReadWriteAppContext>();
        }
    }
}
