using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.DTOs
{
    public class ProductBillInfoDTO
    {
        public ProductBillInfoDTO()
        {

        }
        public string BillId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal PricePerItem { get; set; }
        public string PricePerItemStr
        {
            get
            {
                return Helper.FormatDecimal(PricePerItem);
            }
        }
        public string TotalPriceStr
        {
            get
            {
                return Helper.FormatVNMoney(Quantity * PricePerItem);
            }
        }
    }
}
