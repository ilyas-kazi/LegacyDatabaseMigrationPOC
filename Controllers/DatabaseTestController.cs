using System;
using System.Web.Mvc;
using LegacyDatabaseMigrationPOC.Data;

namespace LegacyDatabaseMigrationPOC.Controllers
{
    public class DatabaseTestController : Controller
    {
        public ActionResult Current()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Database.Connection.Open();

                    var connectionType = db.Database.Connection.GetType().FullName;
                    var databaseName = db.Database.Connection.Database;
                    var serverVersion = db.Database.Connection.ServerVersion;

                    return Content(
                        $"Database: {databaseName}{Environment.NewLine}" +
                        $"Connection Type: {connectionType}{Environment.NewLine}" +
                        $"Server Version: {serverVersion}"
                    );
                }
            }
            catch (Exception ex)
            {
                return Content("Connection FAILED:" + Environment.NewLine + ex);
            }
        }

        public ActionResult SqlServer()
        {
            try
            {
                using (var db = new AppDbContext("SqlServerConnection"))
                {
                    var canConnect = db.Database.Exists();

                    return Content(
                        canConnect
                            ? "SqlServer connection successful."
                            : "SqlServer database does not exist.");
                }
            }
            catch (Exception ex)
            {
                return Content("SqlServer connection failed: " + ex.Message);
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
    }
}