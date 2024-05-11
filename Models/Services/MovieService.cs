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
using System.Windows.Automation.Peers;

namespace cinema_management.Models.Services
{
    internal class MovieService
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
                    using (var context = new CinemaManagementEntities8())
                    {
                        movies = await (from movie in context.Movies
                                        where movie.IsDeleted == false
                                        select new MovieDTO
                                        {
                                            Id = (int)movie.MovieId,
                                            DisplayName = (string)movie.DisplayName,
                                            RunningTime = (int)movie.RunningTime,
                                            Country = (string)movie.Country,
                                            Description = movie.Description,
                                            ReleaseYear = (int)movie.ReleaseYear,
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
                    using (var context = new CinemaManagementEntities8())
                    {
                        var MovieIDList = await (from showSet in context.ShowtimeSettings
                                                 where DbFunctions.TruncateTime(showSet.ShowDate) == date.Date
                                                 select showSet into S
                                                 from show in S.ShowTimes
                                                 select new
                                                 {
                                                     MovieID = show.MovieID,
                                                     ShowTime = show,
                                                 }).GroupBy(m => m.MovieID).ToListAsync();
                        for (int i = 0; i < MovieIDList.Count(); i++)
                        {
                            int id = (int)MovieIDList[i].Key;

                            List<ShowTimeDTO> showtimeDTOsList = new List<ShowTimeDTO>();
                            MovieDTO mov = null;
                            foreach (var m in MovieIDList[i])
                            {
                                showtimeDTOsList.Add(new ShowTimeDTO
                                {
                                    Id = (int)m.ShowTime.MovieID,
                                    MovieId = (int)m.ShowTime.MovieID,
                                    StartTime = (TimeSpan)m.ShowTime.StartTime,
                                    RoomId = (int)m.ShowTime.ShowtimeSetting.RoomId,
                                    ShowDate = (DateTime)m.ShowTime.ShowtimeSetting.ShowDate,
                                    TicketPrice = (decimal)m.ShowTime.TicketPrice
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
                                        Id = movie.MovieId,
                                        DisplayName = movie.DisplayName,
                                        RunningTime = (int)movie.RunningTime,
                                        Country = movie.Country,
                                        Description = movie.Description,
                                        ReleaseYear = (int)movie.ReleaseYear,
                                        MovieType = movie.MovieType,
                                        Director = movie.Director,
                                        Image = movie.Image,
                                        Genres = (from genre in movie.Genres
                                                  select new GenreDTO {DisplayName = genre.GenreDisplayName, Id = genre.GenreID }
                                                         ).ToList(),
                                    };
                                }
                            }
                            movieList.Add(mov);
                            movieList[i].Showtimes = showtimeDTOsList.OrderBy(s => s.StartTime).ToList();
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
                    using (var context = new CinemaManagementEntities8())
                    {
                        var MovieIDList = await (from showSet in context.ShowtimeSettings
                                                 where DbFunctions.TruncateTime(showSet.ShowDate) == date.Date && showSet.RoomId == roomId
                                                 select showSet into S
                                                 from show in S.ShowTimes
                                                 select new
                                                 {
                                                     MovieID = show.MovieID,
                                                     ShowTime = show,
                                                 }).GroupBy(m => m.MovieID).ToListAsync();
                        for (int i = 0; i < MovieIDList.Count(); i++)
                        {
                            int id = (int)MovieIDList[i].Key;

                            List<ShowTimeDTO> showtimeDTOsList = new List<ShowTimeDTO>();
                            MovieDTO mov = null;
                            foreach (var m in MovieIDList[i])
                            {
                                showtimeDTOsList.Add(new ShowTimeDTO
                                {
                                    Id = (int)m.ShowTime.MovieID,
                                    MovieId = (int)m.ShowTime.MovieID,
                                    StartTime = (TimeSpan)m.ShowTime.StartTime,
                                    RoomId = (int)m.ShowTime.ShowtimeSetting.RoomId,
                                    ShowDate = (DateTime)m.ShowTime.ShowtimeSetting.ShowDate,
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
                                        Id = movie.MovieId,
                                        DisplayName = movie.DisplayName,
                                        RunningTime = (int)movie.RunningTime,
                                        Country = movie.Country,
                                        Description = movie.Description,
                                        ReleaseYear = (int)movie.ReleaseYear,
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
                            movieList[i].Showtimes = showtimeDTOsList.OrderBy(s => s.StartTime).ToList();
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
                    using (var context = new CinemaManagementEntities8())
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
                            m.MovieType = newMovie.MovieType;
                            m.Director = newMovie.Director;
                            m.Image = newMovie.Image;
                            foreach (var g in newMovie.Genres)
                            {
                                Genre genre = context.Genres.Find(g.Id);
                                m.Genres.Add(genre);
                            }
                            m.IsDeleted = false;
                            await context.SaveChangesAsync();
                            newMovie.Id = m.MovieId;
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
                                MovieType = newMovie.MovieType,
                                Director = newMovie.Director,
                                Image = newMovie.Image,
                            };
                            foreach (var g in newMovie.Genres)
                            {
                                Genre genre = context.Genres.Find(g.Id);
                                mov.Genres.Add(genre);
                            }
                            context.Movies.Add(mov);
                            newMovie.Id = mov.MovieId;
                            await context.SaveChangesAsync();
                            
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
                    using (var context = new CinemaManagementEntities8())
                    {
                        Movie movie = context.Movies.Find(updatedMovie.Id);

                        if (movie is null)
                        {
                            return (false, "Phim không tồn tại");
                        }

                        bool IsExistMovieName = context.Movies.Any((Movie mov) => mov.MovieId != movie.MovieId && mov.DisplayName == updatedMovie.DisplayName);
                        if (IsExistMovieName)
                        {
                            return (false, "Tên phim đã tồn tại!");
                        }


                        movie.DisplayName = updatedMovie.DisplayName;
                        movie.RunningTime = updatedMovie.RunningTime;
                        movie.Country = updatedMovie.Country;
                        movie.Description = updatedMovie.Description;
                        movie.ReleaseYear = (int)updatedMovie.ReleaseYear;
                        movie.MovieType = updatedMovie.MovieType;
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
                    using (var context = new CinemaManagementEntities8())
                    {
                        Movie movie = await (from p in context.Movies
                                             where p.MovieId == Id && !p.IsDeleted
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
