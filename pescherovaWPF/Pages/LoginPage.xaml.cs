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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pescherovaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.RegPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string UserLoginDb = Data.EsoftEntities.GetContext().Users
                .Select(user => user.UserLogin)
                .Select(login => login)
                .Where(login => login == LoginTextBox.Text)
                .First();
            string UserPasswordDb = Data.EsoftEntities.GetContext().Users
                .Select(user => user.UserPassword)
                .Select(password => password)
                .Where(password => password == PasswordBox.Password)
                .First();
            if (UserLoginDb == LoginTextBox.Text && UserPasswordDb == PasswordBox.Password)
            {
                Manager.UserLogin = UserLoginDb;
                Manager.UserPassword = UserLoginDb;
                Manager.MainFrame.Navigate(new Pages.UserPage());
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
