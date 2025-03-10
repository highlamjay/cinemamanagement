﻿using cinema_management.DTOs;
using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public class ProductService
    {
        private ProductService() { }

        private static ProductService _ins;
        public static ProductService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ProductService();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<List<ProductDTO>> GetAllProduct()
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    List<ProductDTO> productDTOs = await (from p in context.Products
                                                          where !p.IsDeleted
                                                          select new ProductDTO
                                                          {
                                                              Id = p.ProductID,
                                                              DisplayName = p.DisplayName,
                                                              Price = p.Price,
                                                              Category = p.Categorylog,
                                                              Quantity = p.Quantity,
                                                              Image = p.Image
                                                          }
                     ).ToListAsync();
                    return productDTOs;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public async Task<(bool, string, ProductDTO)> AddNewProduct(ProductDTO newProd)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {

                    Product prod = await context.Products.Where((p) => p.DisplayName == newProd.DisplayName).FirstOrDefaultAsync();

                    if (prod != null)
                    {
                        if (prod.IsDeleted == false)
                        {
                            return (false, "Tên sản phầm đã tồn tại", null);
                        }

                        //Khi sản phẩm đã bị xóa nhưng được add lại với cùng tên 
                        prod.DisplayName = newProd.DisplayName;
                        prod.Price = newProd.Price;
                        prod.Categorylog = newProd.Category;
                        prod.Image = newProd.Image;
                        prod.IsDeleted = false;
                        await context.SaveChangesAsync();
                        newProd.Id = prod.ProductID;
                    }
                    else
                    {
                        Random random = new Random();
                        Product product = new Product
                        {
                            ProductID = random.Next(1000 - (100 - 1)) + 100,
                            DisplayName = newProd.DisplayName,
                            Price = newProd.Price,
                            Categorylog = newProd.Category,
                            Image = newProd.Image,
                        };
                        context.Products.Add(product);
                        await context.SaveChangesAsync();
                        newProd.Id = product.ProductID;
                    }

                    return (true, "Thêm sản phẩm mới thành công", newProd);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, $"Lỗi hệ thống {e}", null);
            }
        }

        public async Task<(bool, string)> UpdateProduct(ProductDTO updatedProd)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Product prod = await context.Products.FindAsync(updatedProd.Id);

                    if (prod is null)
                    {
                        return (false, "Sản phẩm không tồn tại");
                    }

                    bool IsExistProdName = await context.Products.AnyAsync((p) => p.ProductID != prod.ProductID && p.DisplayName == updatedProd.DisplayName);
                    if (IsExistProdName)
                    {
                        return (false, "Tên sản phẩm này đã tồn tại! Vui lòng chọn tên khác");
                    }
                    prod.DisplayName = updatedProd.DisplayName;
                    prod.Price = updatedProd.Price;
                    prod.Image = updatedProd.Image;
                    prod.Categorylog = updatedProd.Category;

                    await context.SaveChangesAsync();
                    return (true, "Cập nhật thành công");
                }
            }
            catch (DbEntityValidationException e)
            {
                return (false, $"DbEntityValidationException {e.Message}");

            }
            catch (DbUpdateException e)
            {
                return (false, $"DbUpdateException: {e.Message}");
            }
            catch (Exception)
            {
                return (false, "Lỗi hệ thống");
            }

        }
        public async Task<(bool, string)> DeleteProduct(int Id)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Product prod = await (from p in context.Products
                                          where p.ProductID == Id && !p.IsDeleted
                                          select p).FirstOrDefaultAsync();
                    if (prod is null)
                    {
                        return (false, "Sản phẩm không tồn tại!");
                    }

                    if (prod.Image != null)
                    {
                        await CloudinaryService.Ins.DeleteImage(prod.Image);
                        prod.Image = null;
                    }
                    prod.IsDeleted = true;

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, $"Lỗi hệ thống {e.Message}");
            }
            return (true, "Xóa sản phẩm thành công");
        }
    }
}