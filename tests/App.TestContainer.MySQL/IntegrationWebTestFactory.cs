using App.Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Respawn;
using Testcontainers.MySql;
using Xunit;

namespace App.TestContainer.MySQL
{
    public class IntegrationWebTestFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MySqlContainer _container = new MySqlBuilder()
            .WithImage("mysql:latest")
            .WithDatabase("ecommercedb")
            .WithUsername("root")
            .WithPassword("P@ssw0r1d")
            .Build();

        private Respawner _respawner = null!;

        public async Task InitializeAsync()
        {
            await _container.StartAsync();

            _respawner = await Respawner.CreateAsync(_container.GetConnectionString(), new RespawnerOptions
            {
                DbAdapter = DbAdapter.Postgres,
                SchemasToInclude = new[] { "public" }
            });
        }

        public new async Task DisposeAsync()
        {
            await _container.DisposeAsync();
        }

        public async Task ResetDatabase()
        {
            await _respawner.ResetAsync(_container.GetConnectionString());
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveDbContext<ApplicationDbContext>();

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseMySQL(_container.GetConnectionString());
                });
                services.EnsureDbCreated<ApplicationDbContext>();
            });
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void RemoveDbContext<T>(this IServiceCollection services) where T : DbContext
        {
            var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<T>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }

        public static void EnsureDbCreated<T>(this IServiceCollection services) where T : DbContext
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var context = serviceProvider.GetRequiredService<T>();
            context.Database.EnsureCreated();
        }
    }
}
