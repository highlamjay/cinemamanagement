using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_management.Utils;

namespace cinema_management.DTOs
{
    public class StaffDTO
    {
        public StaffDTO()
        {
            StaffRole = ROLE.Staff;
        }

        public StaffDTO(string id, string name, string sex, DateTime birthday, string phonenumber, string role, DateTime startingdate)
        {
            StaffId = id; StaffName = name; Sex = sex; StaffBirthDay = birthday; PhoneNumber = phonenumber; StaffRole = role; StartingDate = startingdate;
        }

        private int GetAge(DateTime birthDate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthDate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthDate.DayOfYear > today.DayOfYear) age--;

            return age;
        }


        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string Username { get; set; }
        public string StaffPassword { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<DateTime> StaffBirthDay
        {
            get; set;
        }
        public string Sex { get; set; }
        public Nullable<System.DateTime> StartingDate { get; set; }
        public string StaffRole { get; set; }
        public string Email { get; set; }
        public System.DateTime CreatedAt { get; set; }


        //Statistic
        public decimal BenefitContribution { get; set; }
        public string BenefitContributionStr
        {
            get
            {
                return Helper.FormatVNMoney(BenefitContribution);
            }
        }
    }
}
