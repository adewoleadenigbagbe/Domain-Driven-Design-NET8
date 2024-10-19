using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.Data.MySQL
{
    public class MySqlReadWriteAppContext : ReadWriteAppContext
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ReadWriteAppContext"]!.ConnectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }

    public class MySqlReadAppContext : ReadAppContext
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ReadAppContext"]!.ConnectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }

}
