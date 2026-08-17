using System.Data.Entity;
using LegacyDatabaseMigrationPOC.Models;

namespace LegacyDatabaseMigrationPOC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("AppDbConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}