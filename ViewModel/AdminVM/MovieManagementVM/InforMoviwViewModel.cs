using cinema_management.DTOs;
using cinema_management.Utils;
using cinema_management.Views.Admin.MovieManangement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace cinema_management.ViewModel.AdminVM.MovieManagementVM
{
    public partial class MovieManagementViewModel : BaseViewModel
    {
        public ICommand LoadInforMovieCM { get; set; }

        public async void LoadInforMovie(InforMovie w1)
        {
            List<GenreDTO> tempgenre = new List<GenreDTO>(SelectedItem.Genres);


            movieName = SelectedItem.DisplayName;
            w1.Genre.Text = tempgenre[0].DisplayName;
            movieDirector = SelectedItem.Director;
            movieCountry = SelectedItem.Country;
            movieDuration = SelectedItem.RunningTime.ToString();
            movieDes = SelectedItem.Description;
            movieYear = SelectedItem.ReleaseYear.ToString();
            w1.Year.Text = SelectedItem.ReleaseYear.ToString();

            ImageSource = await CloudinaryService.Ins.LoadImageFromURL(SelectedItem.Image);

        }
    }
}
