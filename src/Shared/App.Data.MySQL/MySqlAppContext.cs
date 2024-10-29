using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using ConfigManager = System.Configuration;

namespace App.Data.MySQL
{
    public class MySqlReadWriteAppContext : ReadWriteAppContext
    {
        private readonly string _connectionString = ApplicationConfig.GetConnectionString("ReadWriteAppContext");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString!);
        }
    }

    public class MySqlReadAppContext : ReadAppContext
    {
        private readonly string _connectionString = ApplicationConfig.GetConnectionString("ReadAppContext");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("the connection string : {0}", _connectionString);
            optionsBuilder.UseMySQL(_connectionString);
        }
    }

}
