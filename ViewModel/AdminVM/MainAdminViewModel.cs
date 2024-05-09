using cinema_management.DTOs;
using cinema_management.Views.Admin;
using cinema_management.Views.LoginWindow;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using cinema_management.Views.Admin.StaffManagement;
using cinema_management.Models.Services;
using cinema_management.ViewModel.AdminVM.ErrorVM;
using cinema_management.Views.Admin.ErrorManagement;
using cinema_management.Views.Admin.StatisticalManagement;
using cinema_management.Views.Admin.CustomerManagement;
using cinema_management.Views.Admin.VoucherManagement;

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
            LoadQLKHPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                SelectedFuncName = "Quản lý khách hàng";
                if (p != null)
                    p.Content = new CustomerManagement();
            });
            LoadTKPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                SelectedFuncName = "Thống kê";
                if (p != null)
                    p.Content = new StatisticalManagement();
            });
            LoadVCPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                SelectedFuncName = "Voucher";
                if (p != null)
                    p.Content = new VoucherManagement();

            });
            LoadErrorPage = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                SelectedFuncName = "Sự cố";
                if (p != null)
                    p.Content = new ErrorManagement();

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

            // this is  the ErrorViewmodel resources
            LoadDetailErrorCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ChoseWindow();
            });
            UpdateErrorCM = new RelayCommand<Window>((p) => { if (IsSaving) return false; return true; }, async (p) =>
            {
                if (SelectedStatus is null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Cảnh báo", "Không hợp lệ!", MessageType.Warning, MessageButtons.OK);
                    mb.ShowDialog();
                    return;
                }
                IsSaving = true;
                await UpdateErrorFunc(p);
                IsSaving = false;
            });
            ReloadErrorListCM = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                ListError = new System.Collections.ObjectModel.ObservableCollection<TroubleDTO>();
                IsGettingSource = true;

                await ReloadErrorList();

                IsGettingSource = false;
            });
            SelectedDate = DateTime.Today;
            SelectedFinishDate = DateTime.Today;
        }
        public async Task CountErrorFunc()
        {
            int counttemp = await TroubleService.Ins.GetWaitingTroubleCount();
            ErrorCount = counttemp.ToString();
        }
    }
}
