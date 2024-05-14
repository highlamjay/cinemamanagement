using cinema_management.DTOs;
using cinema_management.Models.Services;
using cinema_management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cinema_management.ViewModel.AdminVM.StaffManagementVM
{
    public partial class StaffManagementViewModel : BaseViewModel
    {
        public async Task EditStaff(Window p)
        {
            MatKhau = SelectedItem.StaffPassword;

            if (Mail != null)
            {
                if (Mail.Trim() == "")
                {
                    Mail = null;
                }
                else
                {
                    if (!Utils.RegexUtilities.IsValidEmail(Mail))
                    {
                        MessageBoxCustom mb = new MessageBoxCustom("Cảnh báo", "Email không hợp lệ", MessageType.Warning, MessageButtons.OK);
                        mb.ShowDialog();
                        return;
                    }
                }
            }

            (bool isValid, string error) = IsValidData(Utils.Operation.UPDATE);
            if (isValid)
            {
                StaffDTO staff = new StaffDTO();
                staff.StaffId = SelectedItem.StaffId;
                staff.StaffName = Fullname;
                staff.Sex = Gender.Content.ToString();
                staff.StaffBirthDay = Born;
                staff.PhoneNumber = Phone;
                staff.StaffRole = Role.Content.ToString();
                staff.StartingDate = StartDate;
                staff.Username = TaiKhoan;
                staff.Email = Mail;
                (bool successUpdateStaff, string messageFromUpdateStaff) = await StaffService.Ins.UpdateStaff(staff);

                if (successUpdateStaff)
                {
                    LoadStaffListView(Utils.Operation.UPDATE, staff);
                    p.Close();
                    MessageBoxCustom mb = new MessageBoxCustom("Thông báo", messageFromUpdateStaff, MessageType.Success, MessageButtons.OK);
                    mb.ShowDialog();
                    MaskName.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Lỗi", messageFromUpdateStaff, MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }
            }
            else
            {
                MessageBoxCustom mb = new MessageBoxCustom("Cảnh báo", error, MessageType.Warning, MessageButtons.OK);
                mb.ShowDialog();
            }
        }
    }
}
