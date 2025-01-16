using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TestContainer.MySQL;

namespace App.Infastructure.Tests.Queries.Products
{
    public class GetProductsTest : BaseIntegrationTest
    {
        public GetProductsTest(IntegrationWebTestFactory factory) : base(factory)
        {
        }
    }
}
