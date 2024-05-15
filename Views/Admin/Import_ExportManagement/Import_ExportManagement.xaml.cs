using cinema_management.DTOs;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cinema_management.Views.Admin.Import_ExportManagement
{
    /// <summary>
    /// Interaction logic for Import_ExportManagement.xaml
    /// </summary>
    public partial class Import_ExportManagement : Page
    {
        List<MovieDTO> ListSource = new List<MovieDTO>();
        public Import_ExportManagement()
        {
            InitializeComponent();
            this.Language = XmlLanguage.GetLanguage("vi-VN");
        }

    }
}
