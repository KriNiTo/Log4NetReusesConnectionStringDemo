using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Reflection;
using System.Windows;
using System.Linq;

using log4net;


namespace Log4NetReusesConnectionStringDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            logDataGrid.ItemsSource = ((App)Application.Current).LogTable.DefaultView;
        }

    }
}