using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Warehouse.Views;

namespace Warehouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool manager;
        public MainWindow(bool isManager)
        {
            InitializeComponent();
            this.manager = isManager;
            if (manager)
            {
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                mainFrame.Navigate(new ProductPage());
            }
            else
            {
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                history.Text = "История поставок";
                supllier.Text = "Поставка";
                mainFrame.Navigate(new ProductPage());
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void goToProductView(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ProductPage());
        }
    }
}