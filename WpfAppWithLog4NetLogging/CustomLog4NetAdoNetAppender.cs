using System.Configuration;

using log4net.Appender;


namespace Log4NetReusesConnectionStringDemo
{
    public class CustomLog4NetAdoNetAppender : AdoNetAppender
    {
        public new string ConnectionString
        {
            get
            {
                return base.ConnectionString;
            }

            set
            {
                // Getting ConnectionString with name defined in app.config:
                //   /log4net/appender/connectionString/@value
                base.ConnectionString = ConfigurationManager.ConnectionStrings[value].ConnectionString;
            }
        }
    }
}