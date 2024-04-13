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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace cinema_management.Views.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFA5B9D6");
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.Background = new SolidColorBrush(Colors.Transparent);
        }
        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFA5B9D6");
            btn.Background = new SolidColorBrush(Colors.OrangeRed);
        }
        private void Button_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Colors.Transparent);
        }
        private void Loginwindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                imagerotator();
            }));
        }


        int i = 2;

        private void imagerotator()

        {

            Storyboard myStoryboard2 = new Storyboard();

            myStoryboard2.SpeedRatio = 5;

            var fadein = new DoubleAnimation()

            {

                From = 1,

                To = 1,

                Duration = TimeSpan.FromSeconds(2),

            };

            Storyboard.SetTarget(fadein, imgframe);

            Storyboard.SetTargetProperty(fadein, new PropertyPath(ImageBrush.OpacityProperty));

            var sb = new Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed0);

            sb.Begin();

        }
        private void sb_Completed0(object sender, EventArgs e)

        {

            Storyboard myStoryboard2 = new Storyboard();

            myStoryboard2.SpeedRatio = 5;

            var fadein = new DoubleAnimation()

            {

                From = 1,

                To = 1,

                Duration = TimeSpan.FromSeconds(0.5),

            };

            Storyboard.SetTarget(fadein, imgframe);

            Storyboard.SetTargetProperty(fadein, new PropertyPath(ImageBrush.OpacityProperty));

            var sb = new Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed);

            sb.Begin();

        }
        private void sb_Completed(object sender, EventArgs e)

        {

            string strUri2 = String.Format(@"pack://application:,,,/cinema-management;component/Resources/ImageFilm/{0}.jpg", i.ToString());

            i++;

            if (i > 7)//number of pictures

            {

                i = 1;

            }

            imgframe.Source = new BitmapImage(new Uri(strUri2));

            Storyboard myStoryboard2 = new Storyboard();

            myStoryboard2.SpeedRatio = 5;

            var fadein = new DoubleAnimation()

            {

                From = 1,

                To = 1,

                Duration = TimeSpan.FromSeconds(.5),

            };

            Storyboard.SetTarget(fadein, imgframe);

            Storyboard.SetTargetProperty(fadein, new PropertyPath(ImageBrush.OpacityProperty));

            var sb = new Storyboard();

            sb.Children.Add(fadein);

            sb.Begin();

            imagerotator();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
