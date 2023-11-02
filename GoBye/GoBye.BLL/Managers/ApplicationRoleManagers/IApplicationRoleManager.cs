using GoBye.BLL.Dtos.ApplicationRoleDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ApplicationRoleManagers
{
    public interface IApplicationRoleManager
    {
        Task<Response> GetAllAsync();
        Task<Response> GetByIdAsync(string id);
        Task<Response> AddAsync(ApplicationRoleAddDto applicationRoleAddDto);
        Task<Response> UpdateAsync(string id, ApplicationRoleUpdateDto applicationRoleUpdateDto);
        Task<Response> DeleteAsync(string id);
    }
}
