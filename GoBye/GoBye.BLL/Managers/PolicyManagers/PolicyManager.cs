using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.Repos.PolicyRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PolicyManager
{
    public class PolicyManager: IPolicyManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PolicyManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllAsync
        public async Task<IEnumerable<PolicyReadDto>?> GetAllAsync()
        {
            IEnumerable<Policy>? policies = await _unitOfWork.PolicyRepo.GetAllAsync();
            if (policies is not null)
            {
                return policies.Select(x => new PolicyReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdAsync
        public async Task<PolicyReadDto?> GetByIdAsync(int id)
        {
            Policy? policy = await _unitOfWork.PolicyRepo.GetByIdAsync(id);
            if (policy is not null)
            {
                PolicyReadDto policyReadDto = new PolicyReadDto
                {
                    Id = policy.Id,
                    Title = policy.Title,
                    Description = policy.Description,
                };
                return policyReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(PolicyAddDto policyAddDto)
        {
            Policy policy = new Policy
            {
                Title = policyAddDto.Title,
                Description = policyAddDto.Description,
            };
            await _unitOfWork.PolicyRepo.AddAsync(policy);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, PolicyUpdateDto policyUpdateDto)
        {
            Policy? policy = await _unitOfWork.PolicyRepo.GetByIdAsync(id);
            if (policy is not null)
            {
                policy.Title = policyUpdateDto.Title;
                policy.Description = policyUpdateDto.Description;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Policy? policy = await _unitOfWork.PolicyRepo.GetByIdAsync(id);
            if (policy is not null)
            {
                _unitOfWork.PolicyRepo.Delete(policy);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
