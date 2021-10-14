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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
                Manager.MainFrame.GoBack();

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.Users user = new Data.Users()
                {
                    FirstName = FirstNameTextBox.Text,
                    UserLogin = LoginTextBox.Text,
                    UserPassword = PasswordBox.Password
                };
                Data.EsoftEntities.GetContext().Users.Add(user);
                Data.EsoftEntities.GetContext().SaveChangesAsync();
                MessageBox.Show("Вы зарегались!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                if (Manager.MainFrame.CanGoBack)
                    Manager.MainFrame.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не зарегались!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
