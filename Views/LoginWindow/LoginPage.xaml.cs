using cinema_management.ViewModel.LoginVM;
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

namespace cinema_management.Views.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static ProgressBar pgb;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void ProgressBar_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            pgb = sender as ProgressBar;
        }

        private void mainPage_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                FloatingPasswordBox.Focus();
                usernameTextBox.Focus();
                var viewmodel = (LoginViewModel)DataContext;
                if (viewmodel.LoginCM.CanExecute(true))
                    viewmodel.LoginCM.Execute(Error);
            }
        }

        private void loginbtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FloatingPasswordBox.Focus();
            usernameTextBox.Focus();
        }
    }
}
