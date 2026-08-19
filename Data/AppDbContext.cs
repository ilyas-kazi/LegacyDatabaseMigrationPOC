using System;
using System.Configuration;
using System.Data.Entity;
using LegacyDatabaseMigrationPOC.Models;

namespace LegacyDatabaseMigrationPOC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base(GetConnectionStringName())
        {
        }

        public AppDbContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        private static string GetConnectionStringName()
        {
            var provider = ConfigurationManager.AppSettings["DatabaseProvider"];

            if (string.Equals(provider, "PostgreSql", StringComparison.OrdinalIgnoreCase))
            {
                return "PostgresConnection";
            }

            return "SqlServerConnection";
        }

        public DbSet<Customer> Customers { get; set; }
    }
}