using cinema_management.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public class ProductReceiptService
    {
        private ProductReceiptService() { }

        private static ProductReceiptService _ins;
        public static ProductReceiptService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ProductReceiptService();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<List<ProductReceiptDTO>> GetProductReceipt()
        {
            List<ProductReceiptDTO> productReceipts;
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    productReceipts = await (from pr in context.ProductReceipts
                                             orderby pr.TimeOfReceipt descending
                                             select new ProductReceiptDTO
                                             {
                                                 Id = pr.ProductReceiptID,
                                                 ProductId = pr.ProductID,
                                                 ProductName = pr.Product.DisplayName,
                                                 StaffId = pr.Staff.StaffID,
                                                 StaffName = pr.Staff.StaffName,
                                                 Quantity = pr.Quantity,
                                                 ImportPrice = pr.ImportPrice * pr.Quantity,
                                                 CreatedAt = pr.TimeOfReceipt,
                                             }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return productReceipts;
        }

        public async Task<List<ProductReceiptDTO>> GetProductReceipt(int month)
        {
            List<ProductReceiptDTO> productReceipts;
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    productReceipts = await (from pr in context.ProductReceipts
                                             where pr.TimeOfReceipt.Year == DateTime.Today.Year && pr.TimeOfReceipt.Month == month
                                             orderby pr.TimeOfReceipt descending
                                             select new ProductReceiptDTO
                                             {
                                                 Id = pr.ProductReceiptID,
                                                 ProductId = pr.ProductID,
                                                 ProductName = pr.Product.DisplayName,
                                                 StaffId = pr.Staff.StaffID,
                                                 StaffName = pr.Staff.StaffName,
                                                 Quantity = pr.Quantity,
                                                 ImportPrice = pr.ImportPrice * pr.Quantity,
                                                 CreatedAt = pr.TimeOfReceipt,
                                             }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return productReceipts;
        }
        private string CreateNextProdReceiptId(string maxId)
        {
            //NVxxx
            if (maxId is null)
            {
                return "PRC001";
            }
            string newIdString = $"000{int.Parse(maxId.Substring(3)) + 1}";
            return "PRC" + newIdString.Substring(newIdString.Length - 3, 3);
        }
        public async Task<(bool, string, ProductReceiptDTO)> CreateProductReceipt(ProductReceiptDTO newPReceipt)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Product prod = await context.Products.FindAsync(newPReceipt.ProductId);
                    prod.Quantity += newPReceipt.Quantity;

                    string maxId = context.ProductReceipts.Max(pr => pr.ProductReceiptID);

                    ProductReceipt pR = new ProductReceipt
                    {
                        ProductReceiptID = CreateNextProdReceiptId(maxId),
                        ImportPrice = newPReceipt.ImportPrice,
                        ProductID = newPReceipt.ProductId,
                        TimeOfReceipt = DateTime.Now,
                        Quantity = newPReceipt.Quantity,
                        StaffID = newPReceipt.StaffId,
                    };
                    context.ProductReceipts.Add(pR);
                    await context.SaveChangesAsync();

                    newPReceipt.Id = pR.ProductReceiptID;
                }
            }
            catch (Exception e)
            {
                return (false, "Lỗi hệ thống", null);
            }
            return (true, "Lưu thông tin nhập hàng thành công", newPReceipt);
        }
    }
}