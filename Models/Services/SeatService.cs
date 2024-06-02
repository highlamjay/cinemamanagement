using cinema_management.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public class SeatService
    {

        private static SeatService _ins;
        public static SeatService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SeatService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        private SeatService() { }

        public async Task<List<SeatSettingDTO>> GetSeatsByShowtime(int showtimeId)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var seatList = await (from s in context.SeatSettings
                                          where s.ShowTimeID == showtimeId
                                          select new SeatSettingDTO
                                          {
                                              SeatId = s.SeatID,
                                              ShowtimeId = s.ShowTimeID,
                                              Status = s.Status,
                                              Seat = new SeatDTO
                                              {
                                                  Id = s.Seat.SeatID,
                                                  RoomId = s.Seat.RoomID,
                                                  Row = s.Seat.RowOfSeat,
                                                  SeatNumber = s.Seat.SeatNumber,
                                              },
                                          }
                               ).ToListAsync();
                    return seatList;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
