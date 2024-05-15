using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using cinema_management.DTOs;
using cinema_management.Models.Services;
using cinema_management.Views.LoginWindow;
using cinema_management.Views.Admin;
using cinema_management.ViewModel.AdminVM;
using cinema_management.Model.Service;
namespace cinema_management.ViewModel.LoginVM
{
    public class LoginViewModel : BaseViewModel
    {
        public Button LoginBtn { get; set; }
        public static Frame MainFrame { get; set; }
        public Window LoginWindow { get; set; }
        public ICommand ShadowMaskCM { get; set; }
        public ICommand CloseWindowCM { get; set; }
        public ICommand MinimizeWindowCM { get; set; }
        public ICommand MouseLeftButtonDownWindowCM { get; set; }
        public ICommand ForgotPassCM { get; set; }
        public ICommand LoginCM { get; set; }
        public ICommand PasswordChangedCM { get; set; }
        public ICommand LoadLoginPageCM { get; set; }
        public ICommand SaveLoginWindowNameCM { get; set; }
        public ICommand SaveLoginBtnCM { get; set; }
        public ICommand AdminLoginCM { get; set; }


        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private bool isloadding;
        public bool IsLoading
        {
            get { return isloadding; }
            set { isloadding = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedRole;

        public ComboBoxItem SelectedRole
        {
            get { return _SelectedRole; }
            set { _SelectedRole = value; OnPropertyChanged(); }
        }

        private StaffDTO _CurrentStaff;
        public StaffDTO CurrentStaff
        {
            get { return _CurrentStaff; }
            set { _CurrentStaff = value; OnPropertyChanged(); }
        }


        public LoginViewModel()
        {
            try
            {
                (_, _, _) = StaffService.Ins.GetStaffEmail("");
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception)
            {
                MessageBox.Show($"Mất kết nối cơ sở dữ liệu! Vui lòng kiểm tra lại", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MouseLeftButtonDownWindowCM = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            ForgotPassCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                MainFrame.Content = new ForgotPasswordPage();
            });
            LoginCM = new RelayCommand<Label>((p) => { return true; }, async (p) =>
             {
                 string username = Username;
                 string password = Password;

                 IsLoading = true;

                 await CheckValidateAccount(username, password, p);

                 IsLoading = false;
             });
            PasswordChangedCM = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
            LoadLoginPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
              {
                  MainFrame = p;
                  p.Content = new LoginPage();
              });
            SaveLoginWindowNameCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoginWindow = p;
            });
            SaveLoginBtnCM = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                LoginBtn = p;
            });
            AdminLoginCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedRole is null) return;

                if (SelectedRole.Content.ToString() == "Quản lý")
                {
                    LoginWindow.Hide();
                    MainAdminWindow w1 = new MainAdminWindow();
                    MainAdminViewModel.currentStaff = CurrentStaff;
                    w1.CurrentUserName.Content = CurrentStaff.StaffName;
                    w1.Show();
                    LoginWindow.Close();
                    return;
                }
                else
                {
                    
                }
            });
        }

        public async Task CheckValidateAccount(string usn, string pwr, Label lbl)
        {

            if (string.IsNullOrEmpty(usn) || string.IsNullOrEmpty(pwr))
            {
                lbl.Content = "Vui lòng nhập đủ thông tin";
                return;
            }


            LoginBtn.Content = "";
            LoginBtn.IsHitTestVisible = false;
            LoginPage.pgb.Visibility = Visibility.Visible;

            (bool loginSuccess, string message, StaffDTO staff) = await Task<(bool loginSuccess, string message, StaffDTO staff)>.Run(() => StaffService.Ins.Login(usn, pwr));
            CurrentStaff = staff;
            LoginBtn.Content = "Đăng nhập";
            LoginBtn.IsHitTestVisible = true;
            LoginPage.pgb.Visibility = Visibility.Collapsed;
            if (loginSuccess)
            {
                Password = "";
                //TicketBillViewModel.Staff = staff;
                if (staff.StaffRole == "Quản lý")
                {
                    MainFrame.Content = new RolePage();
                }
                else
                {
                    
                }

            }
            else
            {
                lbl.Content = message;
                return;
            }
        }
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
