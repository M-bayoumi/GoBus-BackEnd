using GoBye.BLL.Dtos.ReportDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ReportManagers
{
    public interface IReportManager
    {
        Task<Response> GetAllWithUserInfoAsync();
        Task<Response> GetAllByUserIdAsync(string id);
        Task<Response> GetByIdWithUserInfoAsync(int id);
        Task<Response> AddAsync(ReportAddDto reportAddDto);
        Task<Response> DeleteAsync(int id);
    }
}
