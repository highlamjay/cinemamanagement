using cinema_management.ViewModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace cinema_management.Views.Admin
{
    /// <summary>
    /// Interaction logic for MainAdminWindow.xaml
    /// </summary>
    public partial class MainAdminWindow : Window
    {
        public static ToggleButton Slidebtn;
        public MainAdminWindow()
        {
            InitializeComponent();
            DataContext = new MainAdminViewModel();
        }

        private void mainadminwindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            this.DragMove();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MainFrame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SlideButton.IsChecked = false;
        }
        private void SlideButton_Checked(object sender, RoutedEventArgs e)
        {
            topnotifi.Visibility = Visibility.Collapsed;
            shadow.Visibility = Visibility.Visible;
        }

        private void SlideButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (count.Text != "0")
                topnotifi.Visibility = Visibility.Visible;
            shadow.Visibility = Visibility.Collapsed;
        }

        private void SlideButton_Loaded(object sender, RoutedEventArgs e)
        {
            Slidebtn = SlideButton;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
    }
}
