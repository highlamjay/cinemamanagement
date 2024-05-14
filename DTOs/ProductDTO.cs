using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.DTOs
{
    public class ProductDTO
    {
        public ProductDTO()
        {
        }
        public ProductDTO(int id,
                          string displayname,
                          string category,
                          decimal price,
                          string image,
                          int quantity)
        {
            this.ProductId = id;
            this.ProductDisplayName = displayname;
            this.ProductCategory = category;
            this.ProductPrice = price;
            this.Image = image;
            this.Quantity = quantity;
        }
        public int ProductId { get; set; }
        public string ProductDisplayName { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public string PriceStr
        {
            get
            {
                return Helper.FormatVNMoney(ProductPrice);
            }
        }
        public int Quantity { get; set; }
        public string Image
        {
            get; set;
        }
        public decimal Revenue { get; set; }
        public string RevenueStr
        {
            get
            {
                return Helper.FormatVNMoney(Revenue);
            }
        }
        public int SalesQuantity { get; set; }
    }
}
