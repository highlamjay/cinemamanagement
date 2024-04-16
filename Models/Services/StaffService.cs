using cinema_management.DTOs;
using cinema_management.Utils;
using System;
using System.Data.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_management.Models.Services;
using System.Web;
using System.Security.Cryptography;

namespace cinema_management.Model.Service
{
    public class StaffService
    {
        private StaffService() { }
        private static StaffService _ins;
        public static StaffService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StaffService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public async Task<List<StaffDTO>> GetAllStaff()
        {
            using (var context = new CinemaManagementEntities())
            {
                var staffs = (from s in context.Staffs
                              where s.IsDeleted == false
                              select new StaffDTO
                              {
                                  StaffId = s.StaffID,
                                  StaffBirthDay = s.StaffBirthDay,
                                  Sex = s.Sex,
                                  Username = s.UserName,
                                  StaffName = s.StaffName,
                                  StaffRole = s.StaffRole,
                                  PhoneNumber = s.PhoneNumber,
                                  StartingDate = s.StartingDate,
                                  StaffPassword = s.StaffPassword,
                                  Email = s.Email
                              }).ToListAsync();
                return await staffs;
            }
        }
        public async Task<(bool, string, StaffDTO)> Login(string username, string password)
        {

            string hassPass = Helper.MD5Hash(password);

            try
            {
                using (var context = new CinemaManagementEntities())
                {                    
                    var staff = await (from s in context.Staffs
                                       where s.UserName == username && s.StaffPassword == hassPass
                                       select new StaffDTO
                                       {
                                           StaffId = s.StaffID,
                                           StaffBirthDay = s.StaffBirthDay,
                                           Sex = s.Sex,
                                           Username = s.UserName,
                                           StaffName = s.StaffName,
                                           StaffRole = s.StaffRole,
                                           PhoneNumber = s.PhoneNumber,
                                           StartingDate = s.StartingDate,
                                           Email = s.Email
                                       }).FirstOrDefaultAsync();



                    if (staff == null)
                    {
                        return (false, "Sai tài khoản hoặc mật khẩu", null);
                    }
                    return (true, "", staff);
                }

            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return (false, "Mất kết nối cơ sở dữ liệu", null);
            }
            catch (Exception e)
            {
                return (false, "Lỗi hệ thống", null);
            }


        }
        private string CreateNextStaffId(string maxId)
        {
            //NVxxx
            string newIdString = $"000{int.Parse(maxId.Substring(2)) + 1}";
            return "NV" + newIdString.Substring(newIdString.Length - 3, 3);
        }
        public async Task<(bool, string, StaffDTO)> AddStaff(StaffDTO newStaff)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    bool usernameIsExist = await context.Staffs.AnyAsync(s => s.UserName == newStaff.Username);
                    bool PhoneNumberIsExist = await context.Staffs.AnyAsync(s => s.PhoneNumber == newStaff.PhoneNumber);

                    if (PhoneNumberIsExist)
                    {
                        return (false, "Số điện thoại đã tồn tại!", null);
                    }
                    if (usernameIsExist)
                    {
                        return (false, "Tài khoản đã tồn tại!", null);
                    }

                    if (newStaff.Email != null)
                    {
                        bool emailIsExist = await context.Staffs.AnyAsync(s => s.Email == newStaff.Email);
                        if (emailIsExist)
                        {
                            return (false, "Email đã được đăng kí!", null);
                        }
                    }

                    var maxId = await context.Staffs.MaxAsync(s => s.StaffID);
                    Staff st = Copy(newStaff);                    
                    st.StaffID = CreateNextStaffId(maxId);
                    newStaff.StaffId = st.StaffID;
                    st.StaffPassword = Helper.MD5Hash(newStaff.StaffPassword);

                    context.Staffs.Add(st);
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return (false, "Mất kết nối cơ sở dữ liệu", null);
            }
            catch (Exception)
            {
                return (false, "Lỗi hệ thống", null);
            }
            return (true, "Thêm nhân viên mới thành công", newStaff);
        }
        private Staff Copy(StaffDTO s)
        {
            return new Staff
            {
                StaffBirthDay = s.StaffBirthDay,
                Sex = s.Sex,
                UserName = s.Username,
                StaffName = s.StaffName,
                StaffRole = s.StaffRole,
                PhoneNumber = s.PhoneNumber,
                StartingDate = s.StartingDate,
                Email = s.Email
            };
        }

        public async Task<(bool, string)> UpdateStaff(StaffDTO updatedStaff)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    bool usernameIsExist = await context.Staffs.AnyAsync(s => s.UserName == updatedStaff.Username && s.StaffID != updatedStaff.StaffId);

                    if (usernameIsExist)
                    {
                        return (false, "Tài khoản đăng nhập đã tồn tại");
                    }

                    if (updatedStaff.Email != null)
                    {
                        bool emailIsExist = await context.Staffs.AnyAsync(s => s.Email == updatedStaff.Email && s.StaffID != updatedStaff.StaffId);
                        if (emailIsExist)
                        {
                            return (false, "Email đã được đăng kí!");
                        }
                    }

                    bool PhoneNumberIsExist = await context.Staffs.AnyAsync(s => s.PhoneNumber == updatedStaff.PhoneNumber && s.StaffID != updatedStaff.StaffId);

                    if (PhoneNumberIsExist)
                    {
                        return (false, "Số điện thoại đã tồn tại!");
                    }

                    Staff staff = await context.Staffs.FindAsync(updatedStaff.StaffId);
                    if (staff == null)
                    {
                        return (false, "Nhân viên không tồn tại");
                    }

                    staff.StaffBirthDay = updatedStaff.StaffBirthDay;
                    staff.Sex = updatedStaff.Sex;
                    staff.UserName = updatedStaff.Username;
                    staff.StaffName = updatedStaff.StaffName;
                    staff.StaffRole = updatedStaff.StaffRole;
                    staff.PhoneNumber = updatedStaff.PhoneNumber;
                    staff.StartingDate = updatedStaff.StartingDate;
                    staff.Email = updatedStaff.Email;

                    await context.SaveChangesAsync();
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return (false, "Mất kết nối cơ sở dữ liệu");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, "Error Server");
            }
            return (true, "Cập nhật thành công");

        }

        public async Task<(bool, string)> UpdatePassword(string StaffId, string newPassword)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Staff staff = await context.Staffs.FindAsync(StaffId);
                    if (staff is null)
                    {
                        return (false, "Tài khoản không tồn tại");
                    }

                    staff.StaffPassword = Helper.MD5Hash(newPassword);
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return (false, "Mất kết nối cơ sở dữ liệu");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, "Lỗi hệ thống");
            }
            return (true, "Cập nhật mật khẩu thành công");

        }
        public async Task<(bool, string)> DeleteStaff(string Id)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Staff staff = await (from p in context.Staffs
                                         where p.StaffID.ToString() == Id && p.IsDeleted == false
                                         select p).FirstOrDefaultAsync();
                    if (staff is null || staff?.IsDeleted == true)
                    {
                        return (false, "Nhân viên không tồn tại!");
                    }
                    staff.IsDeleted = true;
                    staff.UserName = null;
                    staff.Email = null;

                    await context.SaveChangesAsync();
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return (false, "Mất kết nối cơ sở dữ liệu");
            }
            catch (Exception)
            {
                return (false, $"Lỗi hệ thống.");
            }
            return (true, "Xóa nhân viên thành công");
        }

        /// <summary>
        /// Dùng để tìm email của staff và gửi mail cho chức năng quên mật khẩu
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public (string error, string email, string Id) GetStaffEmail(string username)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    Staff staff = (from p in context.Staffs
                                   where p.UserName == username && p.IsDeleted == false
                                   select p).FirstOrDefault();
                    if (staff is null || staff?.IsDeleted == true)
                    {
                        return ("Tài khoản đăng nhập không tồn tại!", null, null);
                    }

                    if (staff.Email is null)
                    {
                        return ("Tài khoản chưa đăng kí email. Vui lòng liên hệ quản lý để được hỗ trợ", null, null);
                    }

                    return (null, staff.Email, staff.StaffID.ToString());
                }
            }
            catch (Exception)
            {
                return ($"Lỗi hệ thống.", null, null);
            }
        }

    }
}
