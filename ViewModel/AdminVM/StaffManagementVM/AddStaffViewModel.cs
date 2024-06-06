using cinema_management.DTOs;
using cinema_management.Model.Service;
using cinema_management.Utils;
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
        public async Task AddStaff(Window p)
        {
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

            (bool isValid, string error) = IsValidData(Operation.CREATE);
            if (isValid)
            {
                StaffDTO staff = new StaffDTO();
                staff.StaffName = Fullname;
                staff.Sex = Gender.Content.ToString();
                staff.StaffBirthDay = Born;
                staff.PhoneNumber = Phone;
                staff.StaffRole = Role.Content.ToString();
                staff.StartingDate = StartDate;
                staff.Username = TaiKhoan;
                staff.StaffPassword = MatKhau;
                staff.Email = Mail;

                (bool successAddStaff, string messageFromAddStaff, StaffDTO newStaff) = await StaffService.Ins.AddStaff(staff);

                if (successAddStaff)
                {
                    MaskName.Visibility = Visibility.Collapsed;
                    LoadStaffListView(Operation.CREATE, newStaff);
                    p.Close();
                    MessageBoxCustom mb = new MessageBoxCustom("Thông báo", messageFromAddStaff, MessageType.Success, MessageButtons.OK);
                    mb.ShowDialog();
                }
                else
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Lỗi", messageFromAddStaff, MessageType.Error, MessageButtons.OK);
                    mb.ShowDialog();
                }

            }
            else
            {
                MessageBoxCustom mb = new MessageBoxCustom("Cảnh báo", error, MessageType.Warning, MessageButtons.OK);
                mb.ShowDialog();
            }
        }
        private (bool, string) ValidateAge(DateTime birthDate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = StartDate.Value.Year - birthDate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthDate.DayOfYear > today.DayOfYear) age--;

            if (age < 18) return (false, "Nhân viên chưa đủ 18 tuổi!");
            return (true, null);
        }
    }
}
