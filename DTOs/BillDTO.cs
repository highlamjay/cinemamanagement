using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_management.Utils;

namespace cinema_management.DTOs
{
    public partial class BillDTO
    {
        public BillDTO()
        {
        }

        public string Id { get; set; }

        //Customer
        private string _CustomerId;

        public string CustomerId
        {
            get
            {
                if (_CustomerId is null)
                {
                    return "KH0000";
                }
                return _CustomerId;
            }
            set
            {
                _CustomerId = value;
            }
        }
        private string _CustomerName;
        public string CustomerName
        {
            get
            {
                if (_CustomerName is null)
                {
                    return "Khách vãng lai";
                }
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        private string _PhoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }

        //Staff
        public string StaffId { get; set; }
        public string StaffName { get; set; }

        //Price
        public string OriginalTotalPriceStr { get => Helper.FormatVNMoney(TotalPrice - DiscountPrice); }

        public decimal TotalPrice { get; set; }
        public string TotalPriceStr
        {
            get
            {
                return Helper.FormatVNMoney(TotalPrice);
            }
        }
        public decimal DiscountPrice { get; set; }
        public string DiscountPriceStr
        {
            get
            {
                return Helper.FormatVNMoney(DiscountPrice);
            }
        }
        public DateTime BillTime { get; set; }
        public List<int> VoucherIdList { get; set; }


        //Use 2 list when show details Bill
        public List<ProductBillInfoDTO> ProductBillInfoes { get; set; }
        public TicketBillInfoDTO TicketInfo { get; set; }
    }
}

