using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ApplicationUserManager
{
    public interface IApplicationUserManager
    {
        Task<Response> GetAllUsersWithDetailsAsync();
        Task<Response> GetAllDriversWithDetailsAsync();

        Task<Response> GetAllByRoleAsync(string roleId);

        Task<Response> GetUserByIdWithDetailsAsync(string Id);
        Task<Response> GetDriverByIdWithDetailsAsync(string Id);

        Task<Response> GetByIdAsync(string id);

        Task<Response> AddAsync(RegisterDto registerDto);
        Task<Response> RegisterAsync(RegisterDto registerDto);
        Task<Response> LoginAsync(LoginDto loginDto);
        Task<Response> UpdateAsync(string id, UserUpdateDto userUpdateDto);
        Task<Response> DeleteAsync(string id);
    }
}
