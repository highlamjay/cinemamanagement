using cinema_management.DTOs;
using cinema_management.Views.Admin;
using cinema_management.Views.LoginWindow;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using cinema_management.Views.Admin.MovieManagement;
using cinema_management.Views.Admin.CustomerManagement;
using cinema_management.Views.Admin.StaffManagement;
using cinema_management.Views.Admin.ProductManagement;

namespace cinema_management.ViewModel.AdminVM
{
    public partial class MainAdminViewModel : BaseViewModel
    {
        public static StaffDTO currentStaff;
        public ICommand SignoutCM { get; set; }
        public ICommand LoadQLPPageCM { get; set; }
        public ICommand LoadQLNVPageCM { get; set; }
        public ICommand LoadSuatChieuPageCM { get; set; }
        public ICommand LoadLSPage { get; set; }
        public ICommand LoadTKPageCM { get; set; }
        public ICommand LoadFoodPageCM { get; set; }
        public ICommand LoadErrorPage { get; set; }
        public ICommand LoadVCPageCM { get; set; }
        public ICommand LoadQLKHPageCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand ChangeRoleCM { get; set; }

        private string _SelectedFuncName;
        public string SelectedFuncName
        {
            get { return _SelectedFuncName; }
            set { _SelectedFuncName = value; OnPropertyChanged(); }
        }

        private string _ErrorCount;
        public string ErrorCount
        {
            get { return _ErrorCount; }
            set { _ErrorCount = value; OnPropertyChanged(); }
        }


        public MainAdminViewModel()
        {
            LoadQLPPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Quản lý phim";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new MovieManagement();
            });
            LoadFoodPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Quản lý sản phẩm";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new ProductManagement();
            });
            LoadQLNVPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Quản lý nhân sự";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new StaffManagement();
            });
            LoadQLKHPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Quản lý khách hàng";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new CustomerManagement();
            });
            

        }
    }
}
