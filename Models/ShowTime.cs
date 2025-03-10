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
    
    public partial class ShowTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShowTime()
        {
            this.SeatSettings = new HashSet<SeatSetting>();
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int ShowTimeID { get; set; }
        public int ShowTimeSettingID { get; set; }
        public int MovieID { get; set; }
        public decimal TicketPrice { get; set; }
        public System.TimeSpan StartTime { get; set; }
    
        public virtual Movie Movie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeatSetting> SeatSettings { get; set; }
        public virtual ShowtimeSetting ShowtimeSetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
