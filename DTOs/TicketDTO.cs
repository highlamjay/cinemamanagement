﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.DTOs
{
    public class TicketDTO
    {
        public TicketDTO()
        {
        }
        public int Id { get; set; }
        public int ShowtimeId { get; set; }
        public int SeatId { get; set; }
        private decimal _price;
        public decimal Price { get { return decimal.Truncate(_price); } set { _price = value; } }

        //Use when show bill details 
        public int SeatPosition { get; set; }
    }
}
