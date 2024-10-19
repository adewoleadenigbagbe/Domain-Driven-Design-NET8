using App.Host.Configuration;

namespace App.Host.SelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ServiceRegistration.Register(builder.Services);

        }
    }
}
