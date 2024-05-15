using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.DTOs
{
    public class RoomDTO
    {
        public RoomDTO()
        {
            this.Seats = new List<SeatDTO>();
        }

        public int Id { get; set; }
        public int SeatQuantity { get; set; }
        public IList<SeatDTO> Seats { get; set; }
    }
}
