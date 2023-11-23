using GoBye.BLL.Dtos.ApplicationRoleDtos;
using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.ReportDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Dtos.TripDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ApplicationRoleManagers
{
    public class ApplicationRoleManager:IApplicationRoleManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationRoleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region GetAllAsync
        public async Task<Response> GetAllAsync()
        {
            IEnumerable<ApplicationRole>? applicationRoles = await _unitOfWork.ApplicationRoleRepo.GetAllAsync();
            if (applicationRoles is not null)
            {
                var data = applicationRoles.Select(x => new ApplicationRoleReadDto
                {
                    Id = x.Id,
                    Name= x.Name!
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Roles");
        }
        #endregion


        #region GetByIdAsync
        public async Task<Response> GetByIdAsync(string id)
        {
            ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync(id);
            if (applicationRole is not null)
            {
                var data = new ApplicationRoleReadDto
                {
                    Id = applicationRole.Id,
                    Name = applicationRole.Name!
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"Role with id ({id}) is not found");
        }
        #endregion


        #region AddAsync 
        public async Task<Response> AddAsync(ApplicationRoleAddDto applicationRoleAddDto)
        {
            ApplicationRole applicationRole = new ApplicationRole();

            applicationRole.Name = applicationRoleAddDto.Name;
            await _unitOfWork.ApplicationRoleRepo.AddAsync(applicationRole);

            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if(result)
            {
                return _unitOfWork.Response(true, null, "The Role has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Role");

        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(string id, ApplicationRoleUpdateDto applicationRoleUpdateDto)
        {
            ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync(id);
            if (applicationRole is not null)
            {
                applicationRole.Name = applicationRoleUpdateDto.Name;
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Role has been updated successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to update Role");


            }
            return _unitOfWork.Response(false, null, $"Role with id ({id}) is not found");

        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(string id)
        {
            ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync(id);
            if (applicationRole is not null)
            {
                 _unitOfWork.ApplicationRoleRepo.Delete(applicationRole);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Role has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Role");

            }
            return _unitOfWork.Response(false, null, $"Role with id ({id}) is not found");

        }
        #endregion
    }
}
