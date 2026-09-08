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

        private static string ResolveConnectionString()
        {
            var provider = ConfigurationManager.AppSettings["DatabaseProvider"];
            var envVarName = string.Equals(provider, "PostgreSql", StringComparison.OrdinalIgnoreCase)
                ? "PostgresConnection"
                : "AppDbConnection";
            
            var fromEnv = Environment.GetEnvironmentVariable(envVarName);
            if (!string.IsNullOrEmpty(fromEnv))
                return fromEnv;
            
            return envVarName;
        }

        public DbSet<Customer> Customers { get; set; }
    }
}