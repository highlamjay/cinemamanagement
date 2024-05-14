using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.DTOs
{
    public class TroubleDTO
    {
        public string TroubleId { get; set; }
        public string TroubleTitle { get; set; }
        public string TroubleDescription { get; set; }
        public string TroubleLevel { get; set; }
        public string TroubleStatus { get; set; }
        public DateTime TroubleSubmittedAt { get; set; }
        public string TroubleRepairCostStr
        {
            get
            {
                return Helper.FormatVNMoney(TroubleRepairCost);
            }
        }
        public decimal TroubleRepairCost { get; set; }
        public DateTime? TroubleStartDate { get; set; }
        public DateTime? TroubleFinishDate { get; set; }
        public string Image
        {
            get; set;
        }
        public string StaffId { get; set; }
        public string StaffName { get; set; }

    }
}
