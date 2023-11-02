using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.BLL.Dtos.ReportDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ReportManagers
{
    public class ReportManager:IReportManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithUserInfoAsync
        public async Task<IEnumerable<ReportDetailsDto>?> GetAllWithUserInfoAsync()
        {
            IEnumerable<Report>? reports = await _unitOfWork.ReportRepo.GetAllWithUserInfoAsync();

            if (reports is not null)
            {
                return reports.Select(x => new ReportDetailsDto
                {
                    Id = x.Id,
                    ReservationNumber = x.ReservationNumber,
                    Message = x.Message,
                    UserName = x.User.UserName!,
                    UserEmail = x.User.Email!,
                    UserPhone = x.User.PhoneNumber!,
                    UserId = x.User.Id!,
                });
            }
            return null;
        }
        #endregion


        #region GetAllByUserIdAsync
        public async Task<IEnumerable<ReportUserDto>?> GetAllByUserIdAsync(string id)
        {
            IEnumerable<Report>? reports = await _unitOfWork.ReportRepo.GetAllAsync();

            if (reports is not null)
            {
                IEnumerable<Report>? userReports = reports.Where(x=>x.UserId == id).ToList();
                if (userReports is not null)
                {
                    return userReports.Select(x => new ReportUserDto
                    {
                        Id = x.Id,
                        ReservationNumber = x.ReservationNumber,
                        Message = x.Message,
                    });
                }
            }
            return null;
        }
        #endregion


        #region GetByIdWithUserInfoAsync
        public async Task<ReportDetailsDto?> GetByIdWithUserInfoAsync(int id)
        {
            Report? report = await _unitOfWork.ReportRepo.GetByIdWithUserInfoAsync(id);

            if (report is not null)
            {
                ReportDetailsDto reportDetailsDto = new ReportDetailsDto
                {
                    Id = report.Id,
                    ReservationNumber = report.ReservationNumber,
                    Message = report.Message,
                    UserName = report.User.UserName!,
                    UserEmail = report.User.Email!,
                    UserPhone = report.User.PhoneNumber!,
                    UserId = report.User.Id!,
                };
                return reportDetailsDto;
            }
            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(ReportAddDto reportAddDto)
        {
            Report report = new Report
            {
                ReservationNumber = reportAddDto.ReservationNumber,
                Message = reportAddDto.Message,
                UserId = reportAddDto.UserId,
            };

            await _unitOfWork.ReportRepo.AddAsync(report);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Report? report = await _unitOfWork.ReportRepo.GetByIdAsync(id);

            if (report is not null)
            {
                _unitOfWork.ReportRepo.Delete(report);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
