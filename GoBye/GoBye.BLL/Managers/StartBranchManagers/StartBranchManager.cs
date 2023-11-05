using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.StartBranchDtos;
using GoBye.BLL.Managers.StartBranchManagers;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.Repos.StartBranchRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.StartBranchManagers
{
    public class StartBranchManager : IStartBranchManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public StartBranchManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithDestinationNameAsync
        public async Task<Response> GetAllWithDestinationNameAsync()
        {
            IEnumerable<StartBranch>? startBranches = await _unitOfWork.StartBranchRepo.GetAllWithDestinationNameAsync();
            if (startBranches is not null)
            {
                var data = startBranches.Select(x => new StartBranchWithDestinationNameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                    DestinationName = x.Destination.Name,
                    DestinationId = x.Destination.Id

                });
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Branches");

        }
        #endregion


        #region GetAllByDestinationIdAsync
        public async Task<Response> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<StartBranch>? startBranches = await _unitOfWork.StartBranchRepo.GetAllByDestinationIdAsync(id);
            if (startBranches is not null)
            {
                var data = startBranches.Select(x => new StartBranchReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                });
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, $"There is no Branches with destinationId ({id})");

        }
        #endregion


        #region GetByIdWithDestinationNameAsync
        public async Task<Response> GetByIdWithDestinationNameAsync(int id)
        {
            StartBranch? startBranche = await _unitOfWork.StartBranchRepo.GetByIdWithDestinationNameAsync(id);
            if (startBranche is not null)
            {
                var data = new StartBranchReadDto
                {
                    Id = startBranche.Id,
                    Name = startBranche.Name,
                    Address = startBranche.Address,
                    Phone = startBranche.Phone,
                };
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"Branch with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(StartBranchAddDto startBranchAddDto)
        {
            StartBranch startBranch = new StartBranch
            {
                Name = startBranchAddDto.Name,
                Address = startBranchAddDto.Address,
                Phone = startBranchAddDto.Phone,
                DestinationId = startBranchAddDto.DestinationId,
            };
            await _unitOfWork.StartBranchRepo.AddAsync(startBranch);
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Branch has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Branch");
        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(int id, StartBranchUpdateDto startBranchUpdateDto)
        {
            StartBranch? startBranch = await _unitOfWork.StartBranchRepo.GetByIdAsync(id);
            if (startBranch is not null)
            {
                startBranch.Name = startBranchUpdateDto.Name;
                startBranch.Address = startBranchUpdateDto.Address;
                startBranch.Phone = startBranchUpdateDto.Phone;
                startBranch.DestinationId = startBranchUpdateDto.DestinationId;
            }
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Branch has been updated successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to update Branch");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            StartBranch? startBranch = await _unitOfWork.StartBranchRepo.GetByIdAsync(id);
            if (startBranch is not null)
            {
                _unitOfWork.StartBranchRepo.Delete(startBranch);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Branch has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Branch");
            }
            return _unitOfWork.Response(false, null, $"Branch with id ({id}) is not found");
        }
        #endregion
    }
    
}