using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace cinema_management.Views.Admin.FoodManagement
{
    /// <summary>
    /// Interaction logic for ImportFoodWindow.xaml
    /// </summary>
    public partial class ImportFoodWindow : Window
    {
        public ImportFoodWindow()
        {
            InitializeComponent();
        }
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox t = sender as TextBox;

        if (t.Text.Length <= 0)
            t.Text = "0";
    }

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !IsTextAllowed(e.Text);
    }
}

