using cinema_management.DTOs;
using cinema_management.Models.Services;
using cinema_management.Utils;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using cinema_management.Views.Admin.ProductManagement;

namespace cinema_management.ViewModel.AdminVM.ProductManagementVM
{
    public partial class ProductManagementViewModel : BaseViewModel
    {
        public async Task LoadEditFood(EditProduct wd)
        {
            if (SelectedItem != null)
            {
                DisplayName = SelectedItem.DisplayName;
                wd._category.Text = SelectedItem.Category;
                Price = SelectedItem.Price;
                Image = SelectedItem.Image;
                Id = SelectedItem.Id;
                IsImageChanged = false;

                ImageSource = await CloudinaryService.Ins.LoadImageFromURL(Image);
            }
        }

        public async Task EditFood(Window p)
        {
            if (Id != -1 && IsValidData())
            {
                ProductDTO product = new ProductDTO();
                product.DisplayName = DisplayName;
                product.Category = Category.Content.ToString();
                product.Price = Price;
                product.Id = Id;
                product.Quantity = Quantity;

                if (IsImageChanged)
                {
                    if (Image != null)
                    {
                        await CloudinaryService.Ins.DeleteImage(Image);
                    }

                    product.Image = await Task.Run(() => CloudinaryService.Ins.UploadImage(filepath));

                    if (product.Image is null)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Thông báo", "Lỗi phát sinh trong quá trình lưu ảnh. Vui lòng thử lại", MessageType.Error, MessageButtons.OK);
                        return;
                    }
                }
                else
                {
                    product.Image = Image;
                }

                (bool successUpdateProduct, string messageFromUpdateProduct) = await ProductService.Ins.UpdateProduct(product);

                if (successUpdateProduct)
                {
                    isSaving = false;
                    LoadProductListView(Operation.UPDATE, product);
                    MessageBoxCustom mb = new MessageBoxCustom("Thông báo", messageFromUpdateProduct, MessageType.Success, MessageButtons.OK);
                    mb.ShowDialog();
                    MaskName.Visibility = Visibility.Collapsed;
                    p.Close();
                }
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Lỗi", messageFromUpdateProduct, MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }

            }
            else
            {
                MessageBoxCustom mb = new MessageBoxCustom("Cảnh báo", "Vui lòng nhập đủ thông tin!", MessageType.Warning, MessageButtons.OK);
                mb.ShowDialog();
            }
        }
    }
}
