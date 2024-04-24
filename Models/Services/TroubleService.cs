using cinema_management.DTOs;
using cinema_management.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_management.Models.Services
{
    public class TroubleService
    {
        private static TroubleService _ins;
        public static TroubleService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TroubleService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        private TroubleService()
        {
        }

        private string CreateNextTroubleId(string maxId)
        {
            //TRxxxx
            if (maxId is null)
            {
                return "TR0001";
            }
            string newIdString = $"000{int.Parse(maxId.Substring(2)) + 1}";
            return "TR" + newIdString.Substring(newIdString.Length - 4, 4);
        }
        public async Task<List<TroubleDTO>> GetAllTrouble()
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    List<TroubleDTO> troubleList = await (from trou
                                                          in context.Troubles
                                                          orderby trou.TroubleSubmittedAt descending
                                                          select new TroubleDTO
                                                          {
                                                              TroubleId = trou.TroubleId,
                                                              TroubleTitle = trou.TroubleTitle,
                                                              TroubleDescription = trou.TroubleDescription,
                                                              Image = trou.Image,
                                                              TroubleLevel = trou.TroubleLevel,
                                                              TroubleStatus = trou.TroubleStatus,
                                                              TroubleRepairCost = trou.TroubleRepairCost,
                                                              TroubleSubmittedAt = trou.TroubleSubmittedAt,
                                                              TroubleStartDate = trou.TroubleStartDate,
                                                              TroubleFinishDate = trou.TroubleFinishDate,
                                                              StaffId = trou.StaffId,
                                                              StaffName = trou.Staff.StaffName,
                                                          }).ToListAsync();

                    return troubleList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<(bool, string, TroubleDTO)> CreateNewTrouble(TroubleDTO newTrouble)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    var maxId = await context.Troubles.MaxAsync(t => t.TroubleId);
                    Trouble tr = new Trouble()
                    {
                        TroubleId = CreateNextTroubleId(maxId),
                        TroubleTitle = newTrouble.TroubleTitle,
                        TroubleDescription = newTrouble.TroubleDescription,
                        Image = newTrouble.Image,
                        TroubleStatus = STATUS.WAITING,
                        TroubleLevel = newTrouble.TroubleLevel ?? LEVEL.NORMAL,
                        TroubleSubmittedAt = DateTime.Now,
                        StaffId = newTrouble.StaffId,
                    };
                    context.Troubles.Add(tr);

                    await context.SaveChangesAsync();

                    newTrouble.TroubleId = tr.TroubleId;
                    return (true, null, newTrouble);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<(bool, string)> UpdateTroubleInfo(TroubleDTO updatedTrouble)
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {

                    var trouble = await context.Troubles.FindAsync(updatedTrouble.TroubleId);

                    trouble.TroubleTitle = updatedTrouble.TroubleTitle;
                    trouble.TroubleDescription = updatedTrouble.TroubleDescription;

                    trouble.Image = updatedTrouble.Image;
                    trouble.TroubleSubmittedAt = DateTime.Now;
                    trouble.StaffId = updatedTrouble.StaffId;
                    trouble.TroubleLevel = updatedTrouble.TroubleLevel ?? trouble.TroubleLevel;

                    await context.SaveChangesAsync();

                    return (true, null);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<(bool, string)> UpdateStatusTrouble(TroubleDTO updatedTrouble)
        {
            try
            {

                using (var context = new CinemaManagementEntities())
                {

                    var trouble = await context.Troubles.FindAsync(updatedTrouble.TroubleId);

                    if (updatedTrouble.TroubleStatus == STATUS.IN_PROGRESS)
                    {
                        trouble.TroubleStartDate = updatedTrouble.TroubleStartDate;
                    }
                    else if (updatedTrouble.TroubleStatus == STATUS.DONE)
                    {
                        if (trouble.TroubleStatus == STATUS.WAITING)
                        {
                            trouble.TroubleStartDate = DateTime.Now;
                        }
                        trouble.TroubleFinishDate = updatedTrouble.TroubleFinishDate;
                        trouble.TroubleRepairCost = updatedTrouble.TroubleRepairCost;
                    }
                    else if (updatedTrouble.TroubleStatus == STATUS.CANCEL)
                    {
                        trouble.TroubleFinishDate = DateTime.Now;
                        trouble.TroubleRepairCost = 0;
                    }

                    trouble.TroubleStatus = updatedTrouble.TroubleStatus;

                    await context.SaveChangesAsync();

                    return (true, "Cập nhật thành công");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        public async Task<int> GetWaitingTroubleCount()
        {
            try
            {
                using (var context = new CinemaManagementEntities())
                {
                    return await context.Troubles.CountAsync(t => t.TroubleStatus == STATUS.WAITING);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
