using GoBye.BLL.Dtos.ReportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ReportManagers
{
    public interface IReportManager
    {
        Task<IEnumerable<ReportDetailsDto>?> GetAllWithUserInfoAsync();
        Task<IEnumerable<ReportUserDto>?> GetAllByUserIdAsync(string id);
        Task<ReportDetailsDto?> GetByIdWithUserInfoAsync(int id);
        Task<bool> AddAsync(ReportAddDto reportAddDto);
        Task<bool> DeleteAsync(int id);
    }
}
