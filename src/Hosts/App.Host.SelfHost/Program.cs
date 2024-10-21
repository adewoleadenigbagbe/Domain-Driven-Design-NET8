using App.Host.Configuration;
using App.Host.SystemWeb;

namespace App.Host.SelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            WebApp.Configure(app);
        }
    }
}
