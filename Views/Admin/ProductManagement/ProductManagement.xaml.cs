using cinema_management.DTOs;
using cinema_management.ViewModel.AdminVM.ProductManagementVM;
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

namespace cinema_management.Views.Admin.ProductManagement
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Page
    {
        public ProductManagement()
        {
            InitializeComponent();
            cboxFilter.SelectedIndex = 0;
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
            view.Filter = Filter;
            result.Content = listBox.Items.Count;
            CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
                return true;
            else
                return ((item as ProductDTO).DisplayName.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void cboxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchBox.Text = "";

            if (ProductManagementViewModel.StoreAllFood is null) return;
            var viewmodel = (ProductManagementViewModel)DataContext;
            if (viewmodel.FilterCboxFoodCommand.CanExecute(true))
                viewmodel.FilterCboxFoodCommand.Execute(cboxFilter);
            if (result is null) return;
            result.Content = listBox.Items.Count;
        }
    }
}
