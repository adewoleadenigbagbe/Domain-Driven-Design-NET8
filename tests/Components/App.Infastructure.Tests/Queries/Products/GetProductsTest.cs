using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.Helpers;
using App.Infastructure.Queries.Products;
using App.TestContainer.MySQL;
using Xunit;
using System.Net;

namespace App.Infastructure.Tests.Queries.Products
{
    public class GetProductsTest : BaseIntegrationTest, IAsyncLifetime
    {
        private Func<Task> _resetDatabase;

        public GetProductsTest(IntegrationWebTestFactory factory) : base(factory)
        {
            _resetDatabase = factory.ResetDatabase;
        }

        [Fact]
        public async Task Should_Get_Products()
        {
            //Arrange 
            var products = new List<Product>
            {
                new Product
                {
                    Id = SequentialGuid.Create(),
                    Name = "Diapers",
                    Price = 24.5M,
                    Vat = 3.4M,
                    Category = Category.Clothings,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IsDeprecated = false
                },

                new Product
                {
                    Id = SequentialGuid.Create(),
                    Name = "Harry Potter and the Deathly Hallows",
                    Price = 15.5M,
                    Vat = 2.4M,
                    Category = Category.Books,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IsDeprecated = false
                },

                new Product
                {
                    Id = SequentialGuid.Create(),
                    Name = "WorkStation",
                    Price = 340.5M,
                    Vat = 1.4M,
                    Category = Category.Electronics,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IsDeprecated = false
                },

            };

            await _readWriteAppContext.AddRangeAsync(products);
            await _readWriteAppContext.SaveChangesAsync();

            //Act
            var query = new GetProducts.Query
            {
                Page = 1,
                PageLength = 10
            };

            var handler = new GetProducts.Handler(_readAppContext);
            var result = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.Equal(3, result.Items.Count);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        public Task DisposeAsync()
        {
            return _resetDatabase();
        }

        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }
    }
}
