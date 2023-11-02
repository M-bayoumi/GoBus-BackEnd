using GoBye.BLL.Dtos.ApplicationUserRoleDto;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ApplicationUserRoleManagers
{
    public interface IApplicationUserRoleManager
    {
        Task<Response> AddAsync(ApplicationUserRoleAddDto applicationUserRoleAddDto);
        Task<Response> DeleteAsync(string userId);
    }
}
