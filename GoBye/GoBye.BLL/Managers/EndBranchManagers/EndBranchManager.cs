using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.EndBranchDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.Repos.EndBranchRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.EndBranchManagers
{
    public class EndBranchManager: IEndBranchManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public EndBranchManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithDestinationNameAsync
        public async Task<IEnumerable<EndBranchWithDestinationNameDto>?> GetAllWithDestinationNameAsync()
        {
            IEnumerable<EndBranch>? endBranches = await _unitOfWork.EndBranchRepo.GetAllWithDestinationNameAsync();
            if (endBranches is not null)
            {
                return endBranches.Select(x => new EndBranchWithDestinationNameDto
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
        public async Task<IEnumerable<EndBranchReadDto>?> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<EndBranch>? endBranches = await _unitOfWork.EndBranchRepo.GetAllByDestinationIdAsync(id);
            if (endBranches is not null)
            {
                return endBranches.Select(x => new EndBranchReadDto
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
        public async Task<EndBranchReadDto?> GetByIdWithDestinationNameAsync(int id)
        {
            EndBranch? endBranche = await _unitOfWork.EndBranchRepo.GetByIdWithDestinationNameAsync(id);
            if (endBranche is not null)
            {
                EndBranchReadDto endBranchReadDto = new EndBranchReadDto
                {
                    Id = endBranche.Id,
                    Name = endBranche.Name,
                    Address = endBranche.Address,
                    Phone = endBranche.Phone,
                };
                return endBranchReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(EndBranchAddDto endBranchAddDto)
        {
            EndBranch endBranch = new EndBranch
            {
                Name = endBranchAddDto.Name,
                Address = endBranchAddDto.Address,
                Phone = endBranchAddDto.Phone,
                DestinationId = endBranchAddDto.DestinationId,
            };
            await _unitOfWork.EndBranchRepo.AddAsync(endBranch);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, EndBranchUpdateDto endBranchUpdateDto)
        {
            EndBranch? endBranch = await _unitOfWork.EndBranchRepo.GetByIdAsync(id);
            if (endBranch is not null)
            {
                endBranch.Name = endBranchUpdateDto.Name;
                endBranch.Address = endBranchUpdateDto.Address;
                endBranch.Phone = endBranchUpdateDto.Phone;
                endBranch.DestinationId = endBranchUpdateDto.DestinationId;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            EndBranch? endBranch = await _unitOfWork.EndBranchRepo.GetByIdAsync(id);
            if (endBranch is not null)
            {
                _unitOfWork.EndBranchRepo.Delete(endBranch);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
