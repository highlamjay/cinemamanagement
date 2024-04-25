//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cinema_management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int TicketID { get; set; }
        public string BillID { get; set; }
        public int ShowTimeID { get; set; }
        public int SeatID { get; set; }
        public decimal Price { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ShowTime ShowTime { get; set; }
    }
}