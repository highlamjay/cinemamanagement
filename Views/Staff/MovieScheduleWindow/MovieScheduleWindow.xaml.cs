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

namespace cinema_management.Views.Staff.MovieScheduleWindow
{
    /// <summary>
    /// Interaction logic for MovieScheduleWindow.xaml
    /// </summary>
    public partial class MovieScheduleWindow : Window
    {
        Border ShowTimeSelected = null;

        public MovieScheduleWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ShowTimeSelected != null)
                ShowTimeSelected.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff97c5");

            ShowTimeSelected = (Border)sender;

            ShowTimeSelected.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF6378B");
            if (_Room.Visibility == Visibility.Collapsed)
                _Room.Visibility = Visibility.Visible;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            _Room.Visibility = Visibility.Collapsed;
        }

        private void Movie_Schedule_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
