using cinema_management.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public partial class StatisticsService
    {
        private StatisticsService() { }
        private static StatisticsService _ins;
        public static StatisticsService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StatisticsService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        #region Customer

        public async Task<(List<CustomerDTO>, decimal TicketExpenseOfTop1, decimal ProductExpenseOfTop1)> GetTop5CustomerExpenseByYear(int year)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var cusStatistic = await context.Bills.Where(b => b.BillTime.Year == year && b.CustomerID != null)
                       .GroupBy(b => b.CustomerID)
                       .Select(grC => new
                       {
                           CustomerId = grC.Key,
                           Expense = grC.Sum(c => (Decimal?)(c.TotalPrice + c.DiscountPrice)) ?? 0
                       })
                       .OrderByDescending(b => b.Expense).Take(5)
                       .Join(
                       context.Customers,
                       statis => statis.CustomerId,
                       cus => cus.CustomerID,
                       (statis, cus) => new CustomerDTO
                       {
                           Id = cus.CustomerID,
                           Name = cus.CustomerName,
                           PhoneNumber = cus.PhoneNumber,
                           Expense = statis.Expense
                       }).ToListAsync();

                    decimal TicketExpense = 0, ProductExpense = 0;
                    if (cusStatistic.Count >= 1)
                    {
                        string cusId = cusStatistic.First().Id;
                        TicketExpense = context.Tickets.Where(b => b.Bill.CustomerID == cusId).Sum(t => (decimal?)t.Price) ?? 0;
                        ProductExpense = context.ProductBillInfoes.Where(b => b.Bill.CustomerID == cusId).Sum(t => (decimal?)(t.PricePerItem * t.Quantity)) ?? 0;
                    }
                    return (cusStatistic, Decimal.Truncate(TicketExpense), Decimal.Truncate(ProductExpense));
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<(int NewCustomerQuanity, int TotalCustomerQuantity, int WalkinGuestQuantity)> GetDetailedCustomerStatistics(int year, int month = 0)
        {
            try
            {
                if (month == 0)
                {
                    using (var context = new CinemaManagementEntities())
                    {
                        int NewCustomerQuanity = await context.Customers.CountAsync(c => c.CreateAt.Year == year);
                        int TotalCustomerQuantity = await context.Customers.CountAsync(c => c.Bills.Any(b => b.BillTime.Year == year) || c.CreateAt.Year == year);
                        int WalkinGuestQuantity = await context.Bills.Where(b => b.CustomerID == null && b.BillTime.Year == year).CountAsync();
                        return (NewCustomerQuanity, TotalCustomerQuantity, WalkinGuestQuantity);
                    }
                }
                else
                {
                    using (var context = new CinemaManagementEntities())
                    {
                        int NewCustomerQuanity = await context.Customers.CountAsync(c => c.CreateAt.Year == year && c.CreateAt.Month == month);
                        int TotalCustomerQuantity = await context.Customers
                            .CountAsync(c => c.Bills.Any(b => b.BillTime.Year == year && b.BillTime.Month == month) || (c.CreateAt.Year == year && c.CreateAt.Month == month));
                        int WalkinGuestQuantity = await context.Bills.Where(b => b.CustomerID == null && b.BillTime.Year == year && b.BillTime.Month == month).CountAsync();
                        return (NewCustomerQuanity, TotalCustomerQuantity, WalkinGuestQuantity);
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<(List<CustomerDTO>, decimal TicketExpenseOfTop1, decimal ProductExpenseOfTop1)> GetTop5CustomerExpenseByMonth(int month)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    List<CustomerDTO> cusStatistic = await context.Bills.Where(b => b.BillTime.Year == DateTime.Now.Year && b.BillTime.Month == month && b.CustomerID != null)
                        .GroupBy(b => b.CustomerID)
                        .Select(grC => new
                        {
                            CustomerId = grC.Key,
                            Expense = grC.Sum(c => (Decimal?)(c.TotalPrice + c.DiscountPrice)) ?? 0
                        })
                        .OrderByDescending(b => b.Expense).Take(5)
                        .Join(
                        context.Customers,
                        statis => statis.CustomerId,
                        cus => cus.CustomerID,
                        (statis, cus) => new CustomerDTO
                        {
                            Id = cus.CustomerID,
                            Name = cus.CustomerName,
                            PhoneNumber = cus.PhoneNumber,
                            Expense = statis.Expense

                        }).ToListAsync();

                    decimal TicketExpense = 0, ProductExpense = 0;
                    if (cusStatistic.Count >= 1)
                    {
                        string cusId = cusStatistic.First().Id;
                        TicketExpense = context.Tickets.Where(b => b.Bill.CustomerID == cusId).Sum(t => (decimal?)t.Price) ?? 0;
                        ProductExpense = context.ProductBillInfoes.Where(b => b.Bill.CustomerID == cusId).Sum(t => (decimal?)(t.PricePerItem * t.Quantity)) ?? 0;
                    }
                    return (cusStatistic, Decimal.Truncate(TicketExpense), Decimal.Truncate(ProductExpense));
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


        #region Staff

        public async Task<List<StaffDTO>> GetTop5ContributionStaffByYear(int year)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var staffStatistic = context.Bills.Where(b => b.BillTime.Year == year)
                    .GroupBy(b => b.StaffID)
                    .Select(grB => new
                    {
                        StaffId = grB.Key,
                        BenefitContribution = grB.Sum(b => (Decimal?)b.TotalPrice) ?? 0
                    })
                    .OrderByDescending(b => b.BenefitContribution).Take(5)
                    .Join(
                    context.Staffs,
                    statis => statis.StaffId,
                    staff => staff.StaffID,
                    (statis, staff) => new StaffDTO
                    {
                        StaffId = staff.StaffID,
                        StaffName = staff.StaffName,
                        BenefitContribution = statis.BenefitContribution
                    }).ToListAsync();

                    return await staffStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<StaffDTO>> GetTop5ContributionStaffByMonth(int month)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var staffStatistic = context.Bills.Where(b => b.BillTime.Year == DateTime.Today.Year && b.BillTime.Month == month)
                   .GroupBy(b => b.StaffID)
                   .Select(grB => new
                   {
                       StaffId = grB.Key,
                       BenefitContribution = grB.Sum(b => (Decimal?)b.TotalPrice) ?? 0
                   })
                   .OrderByDescending(b => b.BenefitContribution).Take(5)
                   .Join(
                   context.Staffs,
                   statis => statis.StaffId,
                   staff => staff.StaffID,
                   (statis, staff) => new StaffDTO
                   {
                       StaffId = staff.StaffID,
                       StaffName = staff.StaffName,
                       BenefitContribution = statis.BenefitContribution
                   }).ToListAsync();

                    return await staffStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<decimal> GetTotalBenefitContributionOfStaffs(int year, int month = 0)
        {
            try
            {
                if (month == 0)
                {
                    using (var context = new CinemaManagementEntities())
                    {
                        decimal TotalBenefitContribution = await context.Bills.Where(b => b.BillTime.Year == year).SumAsync(b => (decimal?)b.TotalPrice) ?? 0;
                        return TotalBenefitContribution;
                    }
                }
                else
                {
                    using (var context = new CinemaManagementEntities())
                    {
                        decimal TotalBenefitContribution = await context.Bills.Where(b => b.BillTime.Year == year && b.BillTime.Month == month).SumAsync(b => (decimal?)b.TotalPrice) ?? 0;
                        return TotalBenefitContribution;
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        #endregion

        #region Movie
        public async Task<List<MovieDTO>> GetTop5BestMovieByYear(int year)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var movieStatistic = context.ShowTimes.Where(s => s.ShowtimeSetting.ShowDate.Year == year)
                    .GroupBy(s => s.MovieID)
                    .Select(gr => new
                    {
                        MovieId = gr.Key,
                        Revenue = gr.Sum(s => (s.Tickets.Count() * s.TicketPrice)),
                        TicketCount = gr.Sum(s => s.Tickets.Count())
                    })
                    .OrderByDescending(m => m.Revenue).Take(5)
                    .Join(
                    context.Movies,
                    statis => statis.MovieId,
                    movie => movie.MovieID,
                    (statis, movie) => new MovieDTO
                    {
                        Id = movie.MovieID,
                        DisplayName = movie.DisplayName,
                        Revenue = statis.Revenue,
                        TicketCount = statis.TicketCount
                    }).ToListAsync();

                    return await movieStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<MovieDTO>> GetTop5BestMovieByMonth(int month)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var movieStatistic = context.ShowTimes.Where(s => s.ShowtimeSetting.ShowDate.Year == DateTime.Today.Year && s.ShowtimeSetting.ShowDate.Month == month)
                    .GroupBy(s => s.MovieID)
                    .Select(gr => new
                    {
                        MovieId = gr.Key,
                        Revenue = gr.Sum(s => (s.Tickets.Count() * s.TicketPrice)),
                        TicketCount = gr.Sum(s => s.Tickets.Count())
                    })
                    .OrderByDescending(m => m.Revenue).Take(5)
                    .Join(
                    context.Movies,
                    statis => statis.MovieId,
                    movie => movie.MovieID,
                    (statis, movie) => new MovieDTO
                    {
                        Id = movie.MovieID,
                        DisplayName = movie.DisplayName,
                        Revenue = statis.Revenue,
                        TicketCount = statis.TicketCount
                    }).ToListAsync();
                    return await movieStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Product
        public async Task<List<ProductDTO>> GetTop5BestProductByYear(int year)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var prodStatistic = context.ProductBillInfoes.Where(b => b.Bill.BillTime.Year == year)
                    .GroupBy(pBill => pBill.ProductID)
                    .Select(gr => new
                    {
                        ProductId = gr.Key,
                        Revenue = gr.Sum(pBill => (Decimal?)(pBill.Quantity * pBill.PricePerItem)) ?? 0,
                        SalesQuantity = gr.Sum(pBill => (int?)pBill.Quantity) ?? 0
                    })
                    .OrderByDescending(m => m.Revenue).Take(5)
                    .Join(
                    context.Products,
                    statis => statis.ProductId,
                    prod => prod.ProductID,
                    (statis, prod) => new ProductDTO
                    {
                        Id = prod.ProductID,
                        DisplayName = prod.DisplayName,
                        Revenue = statis.Revenue,
                        SalesQuantity = statis.SalesQuantity
                    }).ToListAsync();

                    return await prodStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<ProductDTO>> GetTop5BestProductByMonth(int month)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var prodStatistic = context.ProductBillInfoes.Where(b => b.Bill.BillTime.Year == DateTime.Today.Year && b.Bill.BillTime.Month == month)
                    .GroupBy(pBill => pBill.ProductID)
                    .Select(gr => new
                    {
                        ProductId = gr.Key,
                        Revenue = gr.Sum(pBill => (Decimal?)(pBill.Quantity * pBill.PricePerItem)) ?? 0,
                        SalesQuantity = gr.Sum(pBill => (int?)pBill.Quantity) ?? 0
                    })
                    .OrderByDescending(m => m.Revenue).Take(5)
                    .Join(
                    context.Products,
                    statis => statis.ProductId,
                    prod => prod.ProductID,
                    (statis, prod) => new ProductDTO
                    {
                        Id = prod.ProductID,
                        DisplayName = prod.DisplayName,
                        Revenue = statis.Revenue,
                        SalesQuantity = statis.SalesQuantity
                    }).ToListAsync();
                    return await prodStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
