using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows;

using log4net;
using log4net.Config;

// Configures Log4Net. Reads Configuration from app.config:
[assembly : XmlConfigurator]


namespace Log4NetReusesConnectionStringDemo
{
    public partial class App : Application
    {
        public DataTable LogTable { get; private set; }

        public App()
        {
            CreateSomeLogOutput();

            LogTable = ReadFromDatabase();
        }

        private static void CreateSomeLogOutput()
        {
            ILog log = LogManager.GetLogger("Example.MyLogger");

            log.Info("Hello World");
            log.Error("This is an error message!");
            log.Warn("And the last...");
        }

        private static DataTable ReadFromDatabase()
        {
            // ConnectionString - read from App.config.
            string connectionString = ConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString;

            using(SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter("SELECT * FROM LOG", connection);

                DataTable table = new DataTable("Log");
                dataAdapter.Fill(table);
                return table;
            }
        }
    }
}