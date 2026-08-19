using System;
using System.Web.Mvc;
using LegacyDatabaseMigrationPOC.Data;

namespace LegacyDatabaseMigrationPOC.Controllers
{
    public class DatabaseTestController : Controller
    {
        public ActionResult Mssql()
        {
            try
            {
                using (var db = new AppDbContext("MssqlConnection"))
                {
                    var canConnect = db.Database.Exists();

                    return Content(
                        canConnect
                            ? "MSSQL connection successful."
                            : "MSSQL database does not exist.");
                }
            }
            catch (Exception ex)
            {
                return Content("MSSQL connection failed: " + ex.Message);
            }
        }

        public ActionResult PostgreSql()
        {
            try
            {
                using (var db = new AppDbContext("PostgresConnection"))
                {
                    db.Database.Connection.Open();

                    var databaseName = db.Database.Connection.Database;
                    var serverVersion = db.Database.Connection.ServerVersion;

                    db.Database.Connection.Close();

                    return Content(
                        $"PostgreSQL connection successful.{Environment.NewLine}" +
                        $"Database: {databaseName}{Environment.NewLine}" +
                        $"Server version: {serverVersion}");
                }
            }
            catch (Exception ex)
            {
                return Content(
                    "PostgreSQL connection FAILED." +
                    Environment.NewLine +
                    Environment.NewLine +
                    ex.ToString());
            }
        }

        public ActionResult PostgreSql_old()
        {
            try
            {
                using (var db = new AppDbContext("PostgresConnection"))
                {
                    var canConnect = db.Database.Exists();

                    return Content(
                        canConnect
                            ? "PostgreSQL connection successful."
                            : "PostgreSQL database does not exist.");
                }
            }
            catch (Exception ex)
            {
                return Content("PostgreSQL connection failed: " + ex.Message);
            }
        }
    }
}