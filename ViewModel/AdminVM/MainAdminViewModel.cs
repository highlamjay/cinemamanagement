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
using cinema_management.Views.Admin.StaffManagement;

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
           
            SignoutCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParentWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Hide();
                    LoginWindow w1 = new LoginWindow();
                    w1.ShowDialog();
                    w.Close();
                }
            });
            LoadQLNVPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                SelectedFuncName = "Quản lý nhân sự";
                if (p != null)
                    p.Content = new StaffManagementPage();
            });

            //======================================
            FrameworkElement GetParentWindow(FrameworkElement p)
            {
                FrameworkElement parent = p;

                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }
                return parent;
            }
        }
    }
}
