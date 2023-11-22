using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Warehouse.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void signIn(object sender, RoutedEventArgs e)
        {
            var win = (login.Text, password.Password) switch
            {
                ("manager", "1234") => new MainWindow(true),
                ("provider", "0000") => new MainWindow(false),
                _ => null
            };

            if (win is null)
            {
                MessageBox.Show("Неверно введен логин или пароль!!!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            win.Show();
            Close();
        }
    }
}
