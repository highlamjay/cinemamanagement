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
using cinema_management.Views.Admin.ShowtimeManagement;
using cinema_management.Views.Admin.ErrorManagement;
using cinema_management.Models.Services;
using cinema_management.Views.Admin.Import_ExportManagement;
using cinema_management.Views.Admin.StatisticManagement;
using cinema_management.Views.Admin.VoucherManagement;

namespace cinema_management.ViewModel
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
            LoadSuatChieuPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Quản lý suất chiếu";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new ShowtimeManagement();
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
            LoadTKPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Thống kê";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new StatisticalManagement();
            });
            LoadLSPage = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Lịch sử";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new Import_ExportManagement();
            });
            LoadVCPageCM = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Voucher";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new VoucherManagement();
            });
            LoadErrorPage = new RelayCommand<Frame>((p) => { return p != null; }, (p) =>
            {
                SelectedFuncName = "Quản lý sự cố";
                if (MainAdminWindow.Slidebtn != null)
                    MainAdminWindow.Slidebtn.IsChecked = false;
                if (p != null)
                    p.Content = new ErrorManagement();
            });

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
