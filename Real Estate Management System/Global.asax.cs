using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Real_Estate_Management_System
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            EnsureCreated();
        }
        private void EnsureCreated()
        {
            Exception exception = null;
            string connString = "Data Source=LAPTOP-NGTI8E14;Integrated Security=True;MultipleActiveResultSets=True";
            bool dbCreated = true;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                object dbId = new SqlCommand("SELECT database_id FROM sys.databases WHERE Name = 'Real_Estate_Management_System'", connection).ExecuteScalar();

                if (dbId == null)
                {
                    dbCreated = false;
                    var command = new SqlCommand(Properties.Resources.DbCreationScript_pt1, connection);
                    command.ExecuteNonQuery();
                }
            }

            if (!dbCreated)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Real_Estate_Management_System"].ToString()))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();
                    var command = new SqlCommand(Properties.Resources.DbCreationScript_pt2, connection)
                    {
                        Transaction = transaction
                    };

                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        exception = ex;
                        connection.Close();
                        SqlConnection.ClearPool(connection);
                    }
                }

                if (exception != null)
                {
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        var command = new SqlCommand("DROP DATABASE Real_Estate_Management_System", connection);
                        command.ExecuteNonQuery();
                    }

                    throw exception;
                }
            }
        }
    }
}
