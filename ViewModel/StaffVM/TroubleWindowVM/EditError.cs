﻿using cinema_management.DTOs;
using cinema_management.Models.Services;
using cinema_management.Utils;
using cinema_management.Views.Staff.TroubeWindow;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace cinema_management.ViewModel.StaffVM.TroubleWindowVM
{
    public partial class TroublePageViewModel : BaseViewModel
    {


        public ICommand LoadEditErrorCM { get; set; }
        public ICommand UpdateErrorCM { get; set; }

        private string troubleID;
        public string TroubleID
        {
            get { return troubleID; }
            set { troubleID = value; }
        }

        public async void LoadEditError(EditError w1)
        {
            IsImageChanged = false;
            Title = SelectedItem.Title;
            w1.staffname.Text = SelectedItem.StaffName;
            w1.cbxStatusError.Text = SelectedItem.Status;
            w1.submitdate.Text = SelectedItem.SubmittedAt.ToShortDateString();
            Level.Content = SelectedItem.Level;
            Description = SelectedItem.Description;
            TroubleID = SelectedItem.Id;

            ImageSource = await CloudinaryService.Ins.LoadImageFromURL(SelectedItem.Image); ;
        }
        public async Task UpdateErrorFunc(EditError p)
        {
            if (TroubleID != null && IsValidData())
            {

                TroubleDTO tb = new TroubleDTO
                {
                    Id = TroubleID,
                    Title = Title,
                    Level = Level.Content.ToString(),
                    Description = Description,
                    StaffId = MainStaffViewModel.CurrentStaff.StaffId,
                };

                if (IsImageChanged)
                {
                    Task<string> uploadImage = CloudinaryService.Ins.UploadImage(filepath);
                    if (SelectedItem.Image != null)
                    {
                        await CloudinaryService.Ins.DeleteImage(SelectedItem.Image);
                    }

                    tb.Image = await uploadImage;

                    if (tb.Image is null)
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Thông báo", "Lỗi phát sinh trong quá trình lưu ảnh. Vui lòng thử lại", MessageType.Error, MessageButtons.OK);
                        return;
                    }
                }
                else
                {
                    tb.Image = SelectedItem.Image;
                }

                (bool successUpdateTB, string messageFromUpdateTB) = await TroubleService.Ins.UpdateTroubleInfo(tb);

                if (successUpdateTB)
                {
                    isSaving = false;
                    MessageBoxCustom mb = new MessageBoxCustom("", "Cập nhật thành công!", MessageType.Success, MessageButtons.OK);
                    mb.ShowDialog();
                    await GetData();

                    MaskName.Visibility = Visibility.Collapsed;
                    p.Close();
                }
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
            }
            else
            {
                MessageBoxCustom mb = new MessageBoxCustom("", "Vui lòng nhập đủ thông tin", MessageType.Warning, MessageButtons.OK);
                mb.ShowDialog();
            }
        }

    }
}
