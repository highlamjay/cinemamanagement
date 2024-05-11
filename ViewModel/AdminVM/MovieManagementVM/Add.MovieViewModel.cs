using cinema_management.DTOs;
using cinema_management.Models.Services;
using cinema_management.Utils;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace cinema_management.ViewModel.AdminVM.MovieManagementVM
{
    public partial class MovieManagementViewModel : BaseViewModel
    {
        public ICommand LoadAddMovieCM { get; set; }
        public async Task SaveMovieFunc(Window p)
        {
            if (filepath != null && IsValidData())
            {
                List<GenreDTO> temp = new List<GenreDTO>
                {
                    movieGenre
                };

                string movieImage = await CloudinaryService.Ins.UploadImage(filepath);

                if (movieImage is null)
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Thông báo", "Lỗi phát sinh trong quá trình lưu ảnh. Vui lòng thử lại", MessageType.Error, MessageButtons.OK);
                    return;
                }

                MovieDTO movie = new MovieDTO
                {
                    DisplayName = movieName,
                    Country = movieCountry,
                    Director = movieDirector,
                    Description = movieDes,
                    Image = movieImage,
                    Genres = temp,
                    ReleaseYear = int.Parse(movieYear),
                    RunningTime = int.Parse(movieDuration),
                };



                (bool successAddMovie, string messageFromAddMovie, MovieDTO newMovie) = await MovieService.Ins.AddMovie(movie);

                if (successAddMovie)
                {
                    isSaving = false;
                    MessageBoxCustom mb = new MessageBoxCustom("Thông báo", messageFromAddMovie, MessageType.Success, MessageButtons.OK);
                    mb.ShowDialog();
                    LoadMovieListView(Operation.CREATE, newMovie);
                    MaskName.Visibility = Visibility.Collapsed;
                    p.Close();
                }
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Lỗi", messageFromAddMovie, MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
            }
            else
            {
                MessageBoxCustom mb = new MessageBoxCustom("Cảnh báo", "Vui lòng nhập đủ thông tin!", MessageType.Warning, MessageButtons.OK);
                mb.ShowDialog();
            }
        }
    }
}
