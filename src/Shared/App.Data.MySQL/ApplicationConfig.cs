using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.MySQL
{
    public static class ApplicationConfig
    {
        private static IConfiguration _configuration;

        static ApplicationConfig()
        {
            var baseDirectory = Directory.GetCurrentDirectory();

            Console.WriteLine("Base Directory: {0}",baseDirectory);

            var builder = new ConfigurationBuilder()
            .SetBasePath(baseDirectory)
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static string GetConnectionString(string key)
        {
            return _configuration.GetConnectionString(key)!;
        }
    }
}
