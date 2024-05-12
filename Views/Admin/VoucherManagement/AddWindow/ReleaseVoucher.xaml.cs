using cinema_management.ViewModel.AdminVM.VoucherManagementVM;
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

namespace cinema_management.Views.Admin.VoucherManagement.AddWindow
{
    /// <summary>
    /// Interaction logic for ReleaseVoucher.xaml
    /// </summary>
    public partial class ReleaseVoucher : Window
    {
        public ReleaseVoucher()
        {
            InitializeComponent();
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddVoucher.topcheck.IsChecked = false;

            VoucherViewModel.WaitingMiniVoucher.Clear();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox temp = (ComboBox)sender;
            ComboBoxItem item = (ComboBoxItem)temp.SelectedItem;

            switch (item.Content.ToString())
            {
                case "Top 5 khách hàng trong tháng":
                    {
                        VoucherViewModel.NumberCustomer = 5;
                        if (maillistbox != null)
                        {
                            addnewemail.IsEnabled = false;
                        }
                        return;
                    }
                case "Khách hàng mới trong tháng":
                    {
                        VoucherViewModel.NumberCustomer = 0;
                        addnewemail.IsEnabled = false;
                        return;
                    }
                case "Khác":
                    {
                        VoucherViewModel.NumberCustomer = -1;
                        addnewemail.IsEnabled = true;
                        return;
                    }
            }
        }
        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            Label lb = sender as Label;

            lb.Content = DateTime.Today.ToShortDateString();
        }
    }
}
