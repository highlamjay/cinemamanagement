using cinema_management.ViewModel.AdminVM.CustomerManagementVM;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace cinema_management.Views.Admin.FoodManagement
{
    /// <summary>
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        public FoodPage()
        {
            InitializeComponent();
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
                return true;
            else
                return ((item as ProductDTO).DisplayName.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
            view.Filter = Filter;
            result.Content = listBox.Items.Count;
            CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void cboxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchBox.Text = "";

            if (FoodManagementViewModel.StoreAllFood is null) return;
            var viewmodel = (FoodManagementViewModel)DataContext;
            if (viewmodel.FilterCboxFoodCommand.CanExecute(true))
                viewmodel.FilterCboxFoodCommand.Execute(cboxFilter);
            if (result is null) return;
            result.Content = listBox.Items.Count;
        }
    }
}
