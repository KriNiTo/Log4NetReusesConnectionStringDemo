using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Reflection;
using System.Windows;
using System.Linq;

using log4net;


namespace Log4NetReusesConnectionStringDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log_ = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly SqlCeConnection sqlConn_ =
                new SqlCeConnection(ConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);

        private SqlCeDataAdapter dataAdapter_;
        private DataTable logTable_;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Exit += ApplicationExit;

            sqlConn_.Open();
            dataAdapter_ = new SqlCeDataAdapter("select * from log", sqlConn_);
            logTable_ = new DataTable("Log");
            dataAdapter_.Fill(logTable_);

            logDataGrid.ItemsSource = logTable_.DefaultView;
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            sqlConn_.Close();
        }

        private void BtnCreateLogClick(object sender, RoutedEventArgs e)
        {
            log_.Info("Neueer LogEintrag!");
          
            //dataAdapter_= new SqlCeDataAdapter("select * from log", sqlConn_);
            dataAdapter_.Fill(logTable_);

            DataTableReader rd = new DataTableReader(logTable_);

            logDataGrid.ItemsSource = rd;

            listBox1.ItemsSource = new string[] {"sdffds", "sdfdsf", "sdfdsf"};

            log_.Info(logTable_.Rows.Count);
            log_.Info(logDataGrid.Items.Count);
        }
    }
}