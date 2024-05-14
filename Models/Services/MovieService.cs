
using cinema_management.DTOs;
using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public class MovieService
    {
        private MovieService() { }

        private static MovieService _ins;
        public static MovieService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MovieService();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<List<MovieDTO>> GetAllMovie()
        {
            List<MovieDTO> movies = null;

            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    movies = await (from movie in context.Movies
                                    where !movie.IsDeleted
                                    select new MovieDTO
                                    {
                                        Id = movie.MovieID,
                                        DisplayName = movie.DisplayName,
                                        RunningTime = movie.RunningTime,
                                        Country = movie.Country,
                                        Description = movie.Description,
                                        ReleaseYear = movie.ReleaseYear,
                                        MovieType = movie.MovieType,
                                        Director = movie.Director,
                                        Image = movie.Image,
                                        Genres = (from genre in movie.Genres
                                                  select new GenreDTO { DisplayName = genre.GenreDisplayName, Id = genre.GenreID }
                                                ).ToList(),
                                    }
                     ).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return movies;
        }


        /// <summary>
        /// Trả về phim và suất chiếu của phim đó trong ngày được truyền vào
        /// </summary>
        /// <param  name="date"></param>
        /// <returns>List<MovieDTO></returns>
        public async Task<List<MovieDTO>> GetShowingMovieByDay(DateTime date)
        {
            List<MovieDTO> movieList = new List<MovieDTO>();
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var MovieIdList = await (from showSet in context.ShowtimeSettings
                                             where DbFunctions.TruncateTime(showSet.ShowDate) == date.Date
                                             select showSet into S
                                             from show in S.ShowTimes
                                             select new
                                             {
                                                 MovieId = show.MovieID,
                                                 ShowTime = show,
                                             }).GroupBy(m => m.MovieId).ToListAsync();
                    for (int i = 0; i < MovieIdList.Count(); i++)
                    {
                        int id = MovieIdList[i].Key;

                        List<ShowtimeDTO> showtimeDTOsList = new List<ShowtimeDTO>();
                        MovieDTO mov = null;
                        foreach (var m in MovieIdList[i])
                        {
                            showtimeDTOsList.Add(new ShowtimeDTO
                            {
                                Id = m.ShowTime.ShowTimeID,
                                MovieId = m.ShowTime.MovieID,
                                StartTime = m.ShowTime.StartTime,
                                RoomId = m.ShowTime.ShowtimeSetting.RoomID,
                                ShowDate = m.ShowTime.ShowtimeSetting.ShowDate,
                                TicketPrice = m.ShowTime.TicketPrice
                            });
                            if (mov is null)
                            {
                                Movie movie = m.ShowTime.Movie;

                                if (movie is null)
                                {
                                    movie = await context.Movies.FindAsync(m.ShowTime.MovieID);
                                }
                                mov = new MovieDTO
                                {
                                    Id = movie.MovieID,
                                    DisplayName = movie.DisplayName,
                                    RunningTime = movie.RunningTime,
                                    Country = movie.Country,
                                    Description = movie.Description,
                                    ReleaseYear = movie.ReleaseYear,
                                    MovieType = movie.MovieType,
                                    Director = movie.Director,
                                    Image = movie.Image,
                                    Genres = (from genre in movie.Genres
                                              select new GenreDTO { DisplayName = genre.GenreDisplayName, Id = genre.GenreID }
                                                     ).ToList(),
                                };
                            }
                        }
                        movieList.Add(mov);
                        movieList[i].ShowTimes = showtimeDTOsList.OrderBy(s => s.StartTime).ToList();
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return movieList;
        }

        /// <summary>
        /// Trả về phim và suất chiếu của phim đó trong ngày được truyền vào và số phòng
        /// </summary>
        /// <param name="date"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<List<MovieDTO>> GetShowingMovieByDay(DateTime date, int roomId)
        {
            List<MovieDTO> movieList = new List<MovieDTO>();
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var MovieIdList = await (from showSet in context.ShowtimeSettings
                                             where DbFunctions.TruncateTime(showSet.ShowDate) == date.Date && showSet.RoomID == roomId
                                             select showSet into S
                                             from show in S.ShowTimes
                                             select new
                                             {
                                                 MovieId = show.MovieID,
                                                 ShowTime = show,
                                             }).GroupBy(m => m.MovieId).ToListAsync();


                    for (int i = 0; i < MovieIdList.Count(); i++)
                    {
                        int id = MovieIdList[i].Key;

                        List<ShowtimeDTO> showtimeDTOsList = new List<ShowtimeDTO>();
                        MovieDTO mov = null;
                        foreach (var m in MovieIdList[i])
                        {
                            showtimeDTOsList.Add(new ShowtimeDTO
                            {
                                Id = m.ShowTime.ShowTimeID,
                                MovieId = m.ShowTime.MovieID,
                                StartTime = m.ShowTime.StartTime,
                                RoomId = m.ShowTime.ShowtimeSetting.RoomID,
                                ShowDate = m.ShowTime.ShowtimeSetting.ShowDate,
                            });
                            if (mov is null)
                            {
                                Movie movie = m.ShowTime.Movie;

                                if (movie is null)
                                {
                                    movie = await context.Movies.FindAsync(m.ShowTime.MovieID);
                                }

                                mov = new MovieDTO
                                {
                                    Id = movie.MovieID,
                                    DisplayName = movie.DisplayName,
                                    RunningTime = movie.RunningTime,
                                    Country = movie.Country,
                                    Description = movie.Description,
                                    ReleaseYear = movie.ReleaseYear,
                                    MovieType = movie.MovieType,
                                    Director = movie.Director,
                                    Image = movie.Image,
                                    Genres = (from genre in movie.Genres
                                              select new GenreDTO { DisplayName = genre.GenreDisplayName, Id = genre.GenreID }
                                                     ).ToList(),
                                };
                            }
                        }
                        movieList.Add(mov);
                        movieList[i].ShowTimes = showtimeDTOsList.OrderBy(s => s.StartTime).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return movieList;
        }

        public async Task<(bool, string, MovieDTO)> AddMovie(MovieDTO newMovie)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Movie m = context.Movies.Where((Movie mov) => mov.DisplayName == newMovie.DisplayName).FirstOrDefault();

                    if (m != null)
                    {
                        if (m.IsDeleted == false)
                        {
                            return (false, "Tên phim đã tồn tại", null);
                        }
                        //Khi phim đã bị xóa nhưng được add lại với cùng tên => update lại phim đã xóa đó với thông tin là 
                        // phim mới thêm thay vì add thêm
                        m.DisplayName = newMovie.DisplayName;
                        m.RunningTime = newMovie.RunningTime;
                        m.Country = newMovie.Country;
                        m.Description = newMovie.Description;
                        m.ReleaseYear = (int)newMovie.ReleaseYear;
                        m.MovieType = newMovie?.MovieType;
                        m.Director = newMovie.Director;
                        m.Image = newMovie.Image;
                        foreach (var g in newMovie.Genres)
                        {
                            Genre genre = context.Genres.Find(g.Id);
                            m.Genres.Add(genre);
                        }
                        m.IsDeleted = false;
                        await context.SaveChangesAsync();
                        newMovie.Id = m.MovieID;
                    }
                    else
                    {
                        Movie mov = new Movie
                        {
                            DisplayName = newMovie.DisplayName,
                            RunningTime = newMovie.RunningTime,
                            Country = newMovie.Country,
                            Description = newMovie.Description,
                            ReleaseYear = (int)newMovie.ReleaseYear,
                            MovieType = newMovie?.MovieType,
                            Director = newMovie.Director,
                            Image = newMovie.Image,
                        };
                        foreach (var g in newMovie.Genres)
                        {
                            Genre genre = context.Genres.Find(g.Id);
                            mov.Genres.Add(genre);
                        }
                        context.Movies.Add(mov);
                        await context.SaveChangesAsync();
                        newMovie.Id = mov.MovieID;
                    }
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return (false, "DbEntityValidationException", null);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, $"Error Server {e}", null);
            }
            return (true, "Thêm phim thành công", newMovie);
        }

        public async Task<(bool, string)> UpdateMovie(MovieDTO updatedMovie)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Movie movie = context.Movies.Find(updatedMovie.Id);

                    if (movie is null)
                    {
                        return (false, "Phim không tồn tại");
                    }

                    bool IsExistMovieName = context.Movies.Any((Movie mov) => mov.MovieID != movie.MovieID && mov.DisplayName == updatedMovie.DisplayName);
                    if (IsExistMovieName)
                    {
                        return (false, "Tên phim đã tồn tại!");
                    }


                    movie.DisplayName = updatedMovie.DisplayName;
                    movie.RunningTime = updatedMovie.RunningTime;
                    movie.Country = updatedMovie.Country;
                    movie.Description = updatedMovie.Description;
                    movie.ReleaseYear = (int)updatedMovie.ReleaseYear;
                    movie.MovieType = updatedMovie?.MovieType;
                    movie.Director = updatedMovie.Director;
                    movie.Image = updatedMovie.Image;

                    await context.SaveChangesAsync();
                    return (true, "Cập nhật thành công");
                }
            }
            catch (DbEntityValidationException e)
            {
                return (false, "DbEntityValidationException");
            }
            catch (DbUpdateException e)
            {
                return (false, $"DbUpdateException: {e.Message}");
            }
            catch (Exception)
            {
                return (false, "Lỗi hệ thống");
            }

        }
        public async Task<(bool, string)> DeleteMovie(int Id)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Movie movie = await (from p in context.Movies
                                         where p.MovieID == Id && !p.IsDeleted
                                         select p).FirstOrDefaultAsync();
                    if (movie == null)
                    {
                        return (false, "Phim không tồn tại!");
                    }

                    if (movie.Image != null)
                    {
                        CloudinaryService.Ins.DeleteImage(movie.Image);
                        movie.Image = null;
                    }
                    movie.IsDeleted = true;


                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                return (false, $"Error Server {e.Message}");
            }
            return (true, "Xóa phim thành công");
        }
    }
}
