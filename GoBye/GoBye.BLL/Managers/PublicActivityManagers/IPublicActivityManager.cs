using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PublicActivityManagers
{
    public interface IPublicActivityManager
    {
        Task<Response> GetAllAsync();
        Task<Response> GetAllByDestinationIdAsync(int id);
        Task<Response> GetByIdAsync(int id);
        Task<Response> AddAsync(PublicActivityAddDto publicActivityAddDto);
        Task<Response> UpdateAsync(int id, PublicActivityUpdateDto publicActivityUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
