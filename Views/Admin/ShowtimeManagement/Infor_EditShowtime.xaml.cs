﻿using cinema_management.ViewModel.AdminVM.ShowtimeManagementVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cinema_management.Views.Admin.ShowtimeManagement
{
    /// <summary>
    /// Interaction logic for Infor_EditShowtime.xaml
    /// </summary>
    public partial class Infor_EditShowtime : Window
    {
        Border SelectedShowtime = null;
        public Infor_EditShowtime()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SelectedShowtime != null)
                SelectedShowtime.BorderBrush = new SolidColorBrush(Colors.Black);

            SelectedShowtime = (Border)sender;

            SelectedShowtime.BorderBrush = new SolidColorBrush(Colors.Red);
        }


        bool IsEdit = false;
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsEdit = !IsEdit;

            if (IsEdit)
            {
                _showtimePrice.IsEnabled = true;
                _lblEdit.Content = "Lưu";
            }
            else
            {
                _showtimePrice.IsEnabled = false;
                _lblEdit.Content = "Thay đổi";
            }

        }
        private void _showtimePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;

            if (t.Text.Length <= 0)
                t.Text = "1";
        }
        private void EditWindow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                ShowtimeManagementViewModel.ShadowMask.Visibility = Visibility.Collapsed;
            }
        }

        private void EditWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
