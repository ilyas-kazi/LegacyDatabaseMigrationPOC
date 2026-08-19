using System.Data.Entity;
using LegacyDatabaseMigrationPOC.Models;

namespace LegacyDatabaseMigrationPOC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("PostgresConnection")
        {
        }

        public AppDbContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
