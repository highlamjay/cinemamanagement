﻿using cinema_management.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace cinema_management.Views.Admin.CustomerManagement
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : Page
    {
        public CustomerManagement()
        {
            InitializeComponent();
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
                return true;

            string searchText = RemoveDiacritics(SearchBox.Text).ToLower();
            var customer = item as CustomerDTO;

            if (customer == null)
                return false;

            switch (cbbFilter.SelectedValue as string)
            {
                case "Mã khách hàng":
                    return RemoveDiacritics(customer.Id.ToString()).ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                case "Tên khách hàng":
                    return RemoveDiacritics(customer.Name).ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                case "Số điện thoại":
                    return RemoveDiacritics(customer.PhoneNumber).ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                default:
                    return RemoveDiacritics(customer.Id.ToString()).ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
            view.Filter = Filter;
            result.Content = _ListView.Items.Count;
            CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
        }
        private void periodbox1_Loaded(object sender, RoutedEventArgs e)
        {
            GetYearSource(Time1);
            return;
        }
        private void periodbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem s = (ComboBoxItem)periodbox1.SelectedItem;
            switch (s.Content.ToString())
            {
                case "Theo năm":
                    {
                        GetYearSource(Time1);
                        return;
                    }
                case "Theo tháng":
                    {
                        GetMonthSource(Time1);
                        return;
                    }
            }
        }
        public void GetYearSource(ComboBox cbb)
        {
            if (cbb is null) return;

            List<string> l = new List<string>();

            int now = -1;
            for (int i = 2020; i <= System.DateTime.Now.Year; i++)
            {
                now++;
                l.Add(i.ToString());
            }
            cbb.ItemsSource = l;
            cbb.SelectedIndex = now;
        }
        public void GetMonthSource(ComboBox cbb)
        {
            if (cbb is null) return;

            List<string> l = new List<string>();

            l.Add("Tháng 1");
            l.Add("Tháng 2");
            l.Add("Tháng 3");
            l.Add("Tháng 4");
            l.Add("Tháng 5");
            l.Add("Tháng 6");
            l.Add("Tháng 7");
            l.Add("Tháng 8");
            l.Add("Tháng 9");
            l.Add("Tháng 10");
            l.Add("Tháng 11");
            l.Add("Tháng 12");

            cbb.ItemsSource = l;
            cbb.SelectedIndex = DateTime.Now.Month - 1;
        }
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }

}
