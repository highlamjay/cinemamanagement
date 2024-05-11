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
using System.Windows.Controls.Primitives;

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
    }
}
