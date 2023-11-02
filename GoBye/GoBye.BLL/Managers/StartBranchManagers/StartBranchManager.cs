using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.StartBranchDtos;
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
    public class StartBranchManager:IStartBranchManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public StartBranchManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithDestinationNameAsync
        public async Task<IEnumerable<StartBranchWithDestinationNameDto>?> GetAllWithDestinationNameAsync()
        {
            IEnumerable<StartBranch>? startBranches = await _unitOfWork.StartBranchRepo.GetAllWithDestinationNameAsync();
            if (startBranches is not null)
            {
                return startBranches.Select(x => new StartBranchWithDestinationNameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                    DestinationName = x.Destination.Name
                    
                });
            }

            return null;
        }
        #endregion


        #region GetAllByDestinationIdAsync
        public async Task<IEnumerable<StartBranchReadDto>?> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<StartBranch>? startBranches = await _unitOfWork.StartBranchRepo.GetAllByDestinationIdAsync(id);
            if (startBranches is not null)
            {
                return startBranches.Select(x => new StartBranchReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdWithDestinationNameAsync
        public async Task<StartBranchReadDto?> GetByIdWithDestinationNameAsync(int id)
        {
            StartBranch? startBranche = await _unitOfWork.StartBranchRepo.GetByIdWithDestinationNameAsync(id);
            if (startBranche is not null)
            {
                StartBranchReadDto startBranchReadDto = new StartBranchReadDto
                {
                    Id = startBranche.Id,
                    Name = startBranche.Name,
                    Address = startBranche.Address,
                    Phone = startBranche.Phone,
                };
                return startBranchReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(StartBranchAddDto startBranchAddDto)
        {
            StartBranch startBranch = new StartBranch
            {
                Name = startBranchAddDto.Name,
                Address = startBranchAddDto.Address,
                Phone = startBranchAddDto.Phone,
                DestinationId = startBranchAddDto.DestinationId,
            };
            await _unitOfWork.StartBranchRepo.AddAsync(startBranch);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, StartBranchUpdateDto startBranchUpdateDto)
        {
            StartBranch? startBranch = await _unitOfWork.StartBranchRepo.GetByIdAsync(id);
            if (startBranch is not null)
            {
                startBranch.Name = startBranchUpdateDto.Name;
                startBranch.Address = startBranchUpdateDto.Address;
                startBranch.Phone = startBranchUpdateDto.Phone;
                startBranch.DestinationId = startBranchUpdateDto.DestinationId;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            StartBranch? startBranch = await _unitOfWork.StartBranchRepo.GetByIdAsync(id);
            if (startBranch is not null)
            {
                _unitOfWork.StartBranchRepo.Delete(startBranch);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
