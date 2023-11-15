using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.BLL.Dtos.ReportDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoBye.BLL.Managers.ReportManagers
{
    public class ReportManager:IReportManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportManager(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        #region GetAllWithUserInfoAsync
        public async Task<Response> GetAllWithUserInfoAsync()
        {
            IEnumerable<Report>? reports = await _unitOfWork.ReportRepo.GetAllWithUserInfoAsync();

            if (reports is not null)
            {
                var data = reports.Select(x => new ReportDetailsDto
                {
                    Id = x.Id,
                    ReservationNumber = x.ReservationNumber,
                    MessageTitle = x.MessageTitle,
                    MessageContent = x.MessageContent,
                    UserName = x.User.UserName!,
                    UserEmail = x.User.Email!,
                    UserPhone = x.User.PhoneNumber!,
                    UserId = x.User.Id!,
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Reports");

        }
        #endregion


        #region GetAllByUserIdAsync
        public async Task<Response> GetAllByUserIdAsync(string id)
        {
            IEnumerable<Report>? reports = await _unitOfWork.ReportRepo.GetAllWithUserInfoAsync();

            if (reports is not null)
            {
                IEnumerable<Report>? userReports = reports.Where(x=>x.UserId == id).ToList();
                if (userReports is not null)
                {
                    var data = userReports.Select(x => new ReportDetailsDto
                    {
                        Id = x.Id,
                        ReservationNumber = x.ReservationNumber,
                        MessageTitle = x.MessageTitle,
                        MessageContent = x.MessageContent,
                        UserId= x.User.Id!,
                        UserName = x.User.UserName!,
                        UserEmail = x.User.Email!,
                        UserPhone = x.User?.PhoneNumber!,
                    });
                    return _unitOfWork.Response(true, data, null);
                }
            }
            return _unitOfWork.Response(false, null, "There is no Reports");

        }
        #endregion


        #region GetByIdWithUserInfoAsync
        public async Task<Response> GetByIdWithUserInfoAsync(int id)
        {
            Report? report = await _unitOfWork.ReportRepo.GetByIdWithUserInfoAsync(id);

            if (report is not null)
            {
                var data = new ReportDetailsDto
                {
                    Id = report.Id,
                    ReservationNumber = report.ReservationNumber,
                    MessageTitle = report.MessageTitle,
                    MessageContent = report.MessageContent,
                    UserName = report.User.UserName!,
                    UserEmail = report.User.Email!,
                    UserPhone = report.User.PhoneNumber!,
                    UserId = report.User.Id!,
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Reports");

        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(ReportAddDto reportAddDto)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(reportAddDto.Email);
            if (user != null)
            {
                Report report = new Report
                {
                    ReservationNumber = reportAddDto.ReservationNumber,
                    MessageTitle = reportAddDto.MessageTitle,
                    MessageContent = reportAddDto.MessageContent,
                    UserId = user.Id,
                };
                await _unitOfWork.ReportRepo.AddAsync(report);
            }

            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Report has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Report");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            Report? report = await _unitOfWork.ReportRepo.GetByIdAsync(id);

            if (report is not null)
            {
                _unitOfWork.ReportRepo.Delete(report);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Report has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Report");
            }
            return _unitOfWork.Response(false, null, $"Report with id ({id}) is not found");
        }
        #endregion
    }
}
