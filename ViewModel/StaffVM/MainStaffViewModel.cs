using cinema_management.DTOs;
using cinema_management.Utils;
using cinema_management.ViewModel.AdminVM;
using cinema_management.Views.Admin;
using cinema_management.Views.LoginWindow;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace cinema_management.ViewModel.StaffVM
{
    public partial class MainStaffViewModel : BaseViewModel
    {
        private ObservableCollection<MovieDTO> _ListMovie;
        public ObservableCollection<MovieDTO> ListMovie
        {
            get { return _ListMovie; }
            set { _ListMovie = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MovieDTO> _ListMovie1;
        public ObservableCollection<MovieDTO> ListMovie1
        {
            get { return _ListMovie1; }
            set { _ListMovie1 = value; }
        }

        private ImageSource _ImgSource;
        public ImageSource ImgSource
        {
            get { return _ImgSource; }
            set { _ImgSource = value; }
        }

        private MovieDTO _SelectedItem;
        public MovieDTO SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set { _SelectedDate = value; OnPropertyChanged(); }
        }

        private GenreDTO _SelectedGenre;
        public GenreDTO SelectedGenre
        {
            get { return _SelectedGenre; }
            set { _SelectedGenre = value; OnPropertyChanged(); }
        }

        private DateTime _getCurrentDate;
        public DateTime GetCurrentDate
        {
            get { return _getCurrentDate; }
            set { _getCurrentDate = value; }
        }

        private string _setCurrentDate;
        public string SetCurrentDate
        {
            get { return _setCurrentDate; }
            set { _setCurrentDate = value; OnPropertyChanged(); }
        }

        private ObservableCollection<GenreDTO> _GenreList;
        public ObservableCollection<GenreDTO> GenreList
        {
            get => _GenreList;
            set
            {
                _GenreList = value; OnPropertyChanged();
            }
        }

        public static Grid MaskName { get; set; }
        public static StaffDTO CurrentStaff { get; set; }

        #region commands
        public ICommand CloseMainStaffWindowCM { get; set; }
        public ICommand MinimizeMainStaffWindowCM { get; set; }
        public ICommand MouseMoveWindowCM { get; set; }
        public ICommand LoadMovieScheduleWindow { get; set; }
        public ICommand LoadFoodPageCM { get; set; }
        public ICommand FirstLoadCM { get; set; }
        public ICommand SelectedGenreCM { get; set; }
        public ICommand SelectedDateCM { get; set; }
        public ICommand LoadErrorPageCM { get; set; }
        public ICommand SignoutCM { get; set; }
        public ICommand MaskNameCM { get; set; }
        public ICommand ChangeRoleCM { get; set; }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { _IsLoading = value; OnPropertyChanged(); }
        }

        private bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; OnPropertyChanged(); }
        }


        #endregion
        public MainStaffViewModel()
        {
            FirstLoadCM = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (CurrentStaff.StaffRole == "Quản lý")
                    IsAdmin = true;
                else
                    IsAdmin = false;

            });
            CloseMainStaffWindowCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = Window.GetWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            });
            MinimizeMainStaffWindowCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = Window.GetWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.WindowState = WindowState.Minimized;
                }
            });
            MouseMoveWindowCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = Window.GetWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.DragMove();
                }
            });
            
            SignoutCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Hide();
                LoginWindow w1 = new LoginWindow();
                w1.ShowDialog();
                p.Close();
            });
            MaskNameCM = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                MaskName = p;
            });
            ChangeRoleCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Hide();
                MainAdminWindow w1 = new MainAdminWindow();
                MainAdminViewModel.currentStaff = CurrentStaff;
                w1.CurrentUserName.Content = CurrentStaff.StaffName;
                w1.Show();
                p.Close();
            });
        }
    }
}
