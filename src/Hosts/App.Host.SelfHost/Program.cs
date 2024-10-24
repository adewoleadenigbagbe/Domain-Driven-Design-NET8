using App.Host.Configuration;
using App.Host.SystemWeb;

namespace App.Host.SelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:9060/";

            var builder = WebApplication.CreateBuilder(args);

            Startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            Startup.Configure(app);

            app.Run(baseAddress);
        }
    }
}
