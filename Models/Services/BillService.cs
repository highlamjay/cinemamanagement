//using cinema_management.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace cinema_management.Models.Services
//{
//    public partial class BillService
//    {
//        private static BillService _ins;
//        public static BillService Ins
//        {
//            get
//            {
//                if (_ins == null)
//                {
//                    _ins = new BillService();
//                }
//                return _ins;
//            }
//            private set => _ins = value;
//        }
//        private BillService()
//        {
//        }
//        public async Task<List<BillDTO>> GetAllBill()
//        {
//            try
//            {
//                using (var context = new CinemaManagementEntities())
//                {
//                    var billList = (from b in context.Bills
//                                    orderby b.BillTime descending
//                                    select new BillDTO
//                                    {
//                                        Id = b.BillID,
//                                        StaffId = b.StaffID,
//                                        StaffName = b.Staff.StaffName,
//                                        TotalPrice = b.TotalPrice,
//                                        //DiscountPrice = b.DiscountPrice,
//                                        CustomerId = b.CustomerID,
//                                        CustomerName = b.Customer.CustomerName,
//                                        PhoneNumber = b.Customer.PhoneNumber,
//                                        BillTime = b.BillTime
//                                    }).ToListAsync();
//                    return await billList;
//                }
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        /// <summary>
//        /// Get Bill by particular date
//        /// </summary>
//        /// <param name="date"></param>
//        /// <returns></returns>
//        public async Task<List<BillDTO>> GetBillByDate(DateTime date)
//        {
//            try
//            {
//                using (var context = new CinemaManagementEntities())
//                {
//                    var billList = (from b in context.Bills
//                                    where DbFunctions.TruncateTime(b.BillTime) == date.Date
//                                    orderby b.BillTime descending
//                                    select new BillDTO
//                                    {
//                                        Id = b.BillID,
//                                        StaffId = b.StaffID,
//                                        StaffName = b.Staff.StaffName,
//                                        TotalPrice = b.TotalPrice,
//                                        //DiscountPrice = b.DiscountPrice,
//                                        CustomerId = b.CustomerID,
//                                        CustomerName = b.Customer.CustomerName,
//                                        PhoneNumber = b.Customer.PhoneNumber,
//                                        BillTime = b.BillTime
//                                    }).ToListAsync();
//                    return await billList;
//                }
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        /// <summary>
//        /// Lấy hóa đơn trong tháng nào đó
//        /// </summary>
//        /// <param name="month"></param>
//        /// <returns></returns>
//        public async Task<List<BillDTO>> GetBillByMonth(int month)
//        {
//            try
//            {
//                using (var context = new CinemaManagementEntities())
//                {
//                    var billList = (from b in context.Bills
//                                    where b.BillTime.Year == DateTime.Now.Year && b.BillTime.Month == month
//                                    orderby b.BillTime descending
//                                    select new BillDTO
//                                    {
//                                        Id = b.BillID,
//                                        StaffId = b.StaffID,
//                                        StaffName = b.Staff.StaffName,
//                                        TotalPrice = b.TotalPrice,
//                                        //DiscountPrice = b.DiscountPrice,
//                                        CustomerId = b.CustomerID,
//                                        CustomerName = b.Customer.CustomerName,
//                                        PhoneNumber = b.Customer.PhoneNumber,
//                                        BillTime = b.BillTime
//                                    }).ToListAsync();
//                    return await billList;
//                }
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        /// <summary>
//        /// Lấy thông tin chi tiết của hóa đơn 
//        /// </summary>
//        /// <param name="billId"></param>
//        /// <returns></returns>
//        public async Task<BillDTO> GetBillDetails(string billId)
//        {
//            try
//            {
//                using (var context = new CinemaManagementEntities())
//                {
//                    var bill = await context.Bills.FindAsync(billId);

//                    BillDTO billInfo = new BillDTO
//                    {
//                        Id = bill.BillID,
//                        StaffId = bill.Staff.StaffID,
//                        StaffName = bill.Staff.StaffName,
//                        //DiscountPrice = bill.DiscountPrice,
//                        TotalPrice = bill.TotalPrice,
//                        BillTime = bill.BillTime,
//                        ProductBillInfoes = (from pi in bill.ProductBillInfoes
//                                             select new ProductBillInfoDTO
//                                             {
//                                                 BillId = pi.BillID,
//                                                 ProductId = pi.ProductID,
//                                                 ProductName = pi.Product.DisplayName,
//                                                 PricePerItem = pi.PricePerItem,
//                                                 Quantity = pi.Quantity
//                                             }).ToList(),
//                    };
//                    if (bill.CustomerID != null)
//                    {
//                        billInfo.CustomerId = bill.Customer.CustomerID;
//                        billInfo.CustomerName = bill.Customer.CustomerName;
//                        billInfo.PhoneNumber = bill.Customer.PhoneNumber;
//                    }

//                    var tickets = bill.Tickets;
//                    if (tickets.Count != 0)
//                    {
//                        var showtime = tickets.FirstOrDefault().ShowTime;
//                        int roomId = 0;
//                        List<string> seatList = new List<string>();
//                        foreach (var t in tickets)
//                        {
//                            if (roomId == 0)
//                            {
//                                roomId = t.Seat.RoomID;
//                            }
//                            seatList.Add($"{t.Seat.RowOfSeat}{t.Seat.SeatNumber}");
//                        }
//                        billInfo.TicketInfo = new TicketBillInfoDTO()
//                        {
//                            roomId = roomId,
//                            movieName = showtime.Movie.DisplayName,
//                            ShowDate = showtime.ShowtimeSetting.ShowDate,
//                            StartShowTime = showtime.StartTime,
//                            TotalPriceTicket = tickets.Count() * showtime.TicketPrice,
//                            seats = seatList,
//                        };
//                    }
//                    return billInfo;
//                }
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }
//    }
//}
