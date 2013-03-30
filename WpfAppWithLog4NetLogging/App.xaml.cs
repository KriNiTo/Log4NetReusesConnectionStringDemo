using System.Configuration;
using System.Data.SqlServerCe;
using System.Reflection;
using System.Windows;

using log4net;
using log4net.Config;
[assembly : XmlConfigurator]


namespace Log4NetReusesConnectionStringDemo
{
    public partial class App : Application
    {
        private static readonly ILog log_ = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public App()
        {
            log_.Debug("Hello World!");
        }
    }
}