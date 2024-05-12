using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.DTOs
{
    public class ShowTimeDTO
    {
        public ShowTimeDTO()
        {
        }
        public int Id { get; set; }
        public int MovieId { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime ShowDate { get; set; }
        public int RoomId { get; set; }
        public decimal TicketPrice { get; set; }
        public string TicketPriceStr { get { return Helper.FormatVNMoney(TicketPrice); } }

        public MovieDTO Movie { get; set; }
        //public IList<TicketDTO> Tickets { get; set; }
    }
}
