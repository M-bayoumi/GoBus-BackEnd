using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.Repos.DestinationRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.DestinationManagers
{
    public class DestinationManager : IDestinationManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public DestinationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region GetAllAsync
        public async Task<IEnumerable<DestinationReadDto>?> GetAllAsync()
        {
            IEnumerable<Destination>? destinations = await _unitOfWork.DestinationRepo.GetAllAsync();
            if (destinations is not null)
            {
                return destinations.Select(x => new DestinationReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageURL = x.ImageURL,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdAsync
        public async Task<DestinationReadDto?> GetByIdAsync(int id)
        {
            Destination? destinations = await _unitOfWork.DestinationRepo.GetByIdAsync(id);
            if (destinations is not null)
            {
                DestinationReadDto destinationReadDto = new DestinationReadDto
                {
                    Id = destinations.Id,
                    Name = destinations.Name,
                    ImageURL = destinations.ImageURL,
                };
                return destinationReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(DestinationAddDto destinationAddDto)
        {
            Destination destination = new Destination
            {
                Name = destinationAddDto.Name,
                ImageURL = destinationAddDto.ImageURL,
            };
            await _unitOfWork.DestinationRepo.AddAsync(destination);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto)
        {
            Destination? destination = await _unitOfWork.DestinationRepo.GetByIdAsync(id);
            if (destination is not null)
            {
                destination.Name = destinationUpdateDto.Name;
                destination.ImageURL = destinationUpdateDto.ImageURL;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Destination? destination = await _unitOfWork.DestinationRepo.GetByIdAsync(id);
            if (destination is not null)
            {
                _unitOfWork.DestinationRepo.Delete(destination);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
