using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Dtos.ApplicationUserRoleDto;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ApplicationUserRoleManagers
{
    public class ApplicationUserRoleManager : IApplicationUserRoleManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUserRoleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region AddAsync
        public async Task<Response> AddAsync(ApplicationUserRoleAddDto applicationUserRoleAddDto)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetByIdAsync(applicationUserRoleAddDto.UserId);
            ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync(applicationUserRoleAddDto.RoleId);

            if(applicationUser is not null && applicationRole is not null)
            {
                ApplicationUserRole applicationUserRole = new ApplicationUserRole
                {
                    ApplicationRole = applicationRole,
                    ApplicationUser = applicationUser
                };
                await _unitOfWork.ApplicationUserRoleRepo.AddAsync(applicationUserRole);
                bool addUserToRole = await _unitOfWork.SaveChangesAsync() > 0;

                if (addUserToRole)
                {
                    return _unitOfWork.Response(true, null, $"{applicationUser.UserName} have been assigned to role {applicationRole.Name}");
                }
            }
            return _unitOfWork.Response(false, null, $"Failed to assign {applicationUserRoleAddDto.UserId} to role {applicationUserRoleAddDto.RoleId}");


        }
        #endregion

        #region DeleteAsync
        public async Task<Response> DeleteAsync(string userId)
        {
            ApplicationUserRole? applicationUserRole = await _unitOfWork.ApplicationUserRoleRepo.GetByUserIdAsync(userId);
            if (applicationUserRole is not null)
            {
                _unitOfWork.ApplicationUserRoleRepo.Delete(applicationUserRole);

                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "Roles have been deleted successfully");
                }
            }
            return _unitOfWork.Response(false, null, "Failed to delete Roles");

        }
        #endregion
    }
}
