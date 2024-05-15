using cinema_management.DTOs;
using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public class ShowtimeService
    {
        private static ShowtimeService _ins;
        public static ShowtimeService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ShowtimeService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        private ShowtimeService() { }


        public async Task<(bool IsSuccess, string message)> AddShowtime(ShowTimeDTO newShowtime)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    //Uncomment when release
                    //if (newShowtime.ShowDate < DateTime.Today)
                    //{
                    //    return (false,"Thời gian này đã qua không thể thêm suất chiếu" ,null);
                    //}
                    var showtimeSet = await context.ShowtimeSettings
                    .Where(s => DbFunctions.TruncateTime(s.ShowDate) == newShowtime.ShowDate.Date
                    && s.RoomID == newShowtime.RoomId).FirstOrDefaultAsync();

                    if (showtimeSet == null)
                    {
                        showtimeSet = new ShowtimeSetting
                        {
                            RoomID = newShowtime.RoomId,
                            ShowDate = newShowtime.ShowDate.Date,
                        }; ;
                        context.ShowtimeSettings.Add(showtimeSet);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        ShowTime show = null;

                        Movie m = await context.Movies.FindAsync(newShowtime.MovieId);
                        var newStartTime = newShowtime.StartTime;
                        var newEndTime = newShowtime.StartTime + new TimeSpan(0, m.RunningTime, 0);
                        show = showtimeSet.ShowTimes.AsEnumerable().Where(s =>
                        {
                            var endTime = new TimeSpan(0, s.Movie.RunningTime, 0) + s.StartTime;
                            return TimeBetwwenIn(newStartTime, newEndTime, s.StartTime, endTime + TIME.BreakTime);
                        }).FirstOrDefault();

                        if (show != null)
                        {
                            var endTime = new TimeSpan(0, show.Movie.RunningTime, 0) + show.StartTime;
                            return (false, $"Khoảng thời gian từ {Helper.GetHourMinutes(show.StartTime)} đến {Helper.GetHourMinutes(endTime + TIME.BreakTime)} đã có phim chiếu tại phòng {showtimeSet.RoomID}");
                        }
                    }

                    ShowTime showtime = new ShowTime
                    {
                        MovieID = newShowtime.MovieId,
                        ShowTimeSettingID = showtimeSet.ShowtimeSettingID,
                        StartTime = newShowtime.StartTime,
                        TicketPrice = newShowtime.TicketPrice
                    };
                    context.ShowTimes.Add(showtime);

                    //setting seats in room for new showtime 
                    var seatIds = await (from s in context.Seats
                                         where s.RoomID == showtimeSet.RoomID
                                         select s.SeatID
                           ).ToListAsync();
                    List<SeatSetting> seatSetList = new List<SeatSetting>();
                    foreach (var seatId in seatIds)
                    {
                        seatSetList.Add(new SeatSetting
                        {
                            SeatID = seatId,
                            ShowTimeID = showtime.ShowTimeID
                        });
                    }
                    context.SeatSettings.AddRange(seatSetList);


                    await context.SaveChangesAsync();
                    newShowtime.Id = showtime.ShowTimeID;
                    return (true, "Thêm suất chiếu thành công");
                }
            }
            catch (Exception e)
            {
                return (false, "Lỗi hệ thống" + e.Message);

            }
        }
        public async Task<(bool IsSuccess, string message)> DeleteShowtime(int showtimeId)
        {

            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    ShowTime show = await context.ShowTimes.FindAsync(showtimeId);
                    if (show is null)
                    {
                        return (false, "Suất chiếu không tồn tại!");
                    }
                    context.ShowTimes.Remove(show);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return (false, "Lỗi hệ thống");
            }
            return (true, "Xóa suất chiếu thành công!");
        }
        public async Task<(bool IsSuccess, string message)> UpdateTicketPrice(int showtimeId, decimal price)
        {

            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    ShowTime show = await context.ShowTimes.FindAsync(showtimeId);
                    if (show is null)
                    {
                        return (false, "Suất chiếu không tồn tại!");
                    }
                    show.TicketPrice = price;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return (false, "Lỗi hệ thống");
            }
            return (true, "Cập nhật giá thành công!");
        }
        public async Task<bool> CheckShowtimeHaveBooking(int showtimeId)
        {

            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var IsExist = await context.SeatSettings.AnyAsync(s => s.ShowTimeID == showtimeId && s.Status);
                    return IsExist;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Check (t1,t2) vs (a1,a2)
        bool TimeBetwwenIn(TimeSpan t1, TimeSpan t2, TimeSpan a1, TimeSpan a2)
        {

            if ((t1 >= a1 && t1 <= a2) || (t2 >= a1 && t2 <= a2))
                return true;
            if (t1 <= a1 && t2 >= a2)
            {
                return true;
            }
            // t2 > t1;
            return false;
        }

    }
}
