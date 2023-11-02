using GoBye.BLL.Dtos.BusDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.BusManagers
{
    public class BusManager:IBusManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithBusClassAsync
        public async Task<IEnumerable<BusReadDto>?> GetAllWithBusClassAsync()
        {
            IEnumerable<Bus>? buses = await _unitOfWork.BusRepo.GetAllWithBusClassAsync();
            if (buses is not null)
            {
                return buses.Select(x => new BusReadDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Capacity = x.Capacity,
                    Available = x.Available,
                    CurrentBranch = x.CurrentBranch,
                    Model = x.Model,
                    Year = x.Year,
                    ClassBusName = x.BusClass.Name,
                    DriverId = x.DriverId,
                    NoOfTrips = x.Trips.Count()
                });
            }

            return null;
        }
        #endregion


        #region GetAllByBusClassIdAsync
        public async Task<IEnumerable<BusReadDto>?> GetAllByBusClassIdAsync(int id)
        {
            IEnumerable<Bus>? buses = await _unitOfWork.BusRepo.GetAllByBusClassIdAsync(id);
            if (buses is not null)
            {
                return buses.Select(x => new BusReadDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Capacity = x.Capacity,
                    Available = x.Available,
                    CurrentBranch = x.CurrentBranch,
                    Model = x.Model,
                    Year = x.Year,
                    ClassBusName = x.BusClass.Name,
                    DriverId = x.DriverId,
                    NoOfTrips = x.Trips.Count()
                });
            }

            return null;
        }
        #endregion


        #region GetAllAvailableBusesAsync
        public async Task<IEnumerable<BusAvailableDto>?> GetAllAvailableBusesAsync()
        {
            IEnumerable<Bus>? buses = await _unitOfWork.BusRepo.GetAllWithBusClassAsync();
            if (buses is not null)
            {
                return buses.Select(x => new BusAvailableDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Available = x.Available,
                    CurrentBranch = x.CurrentBranch,
                    ClassBusName = x.BusClass.Name,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdWithBusClassAsync
        public async Task<BusReadDto?> GetByIdWithBusClassAsync(int id)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdWithBusClassAsync(id);
            if (bus is not null)
            {
                BusReadDto busReadDto = new BusReadDto
                {
                    Id = bus.Id,
                    Number = bus.Number,
                    Capacity = bus.Capacity,
                    Available = bus.Available,
                    CurrentBranch = bus.CurrentBranch,
                    Model = bus.Model,
                    Year = bus.Year,
                    ClassBusName = bus.BusClass.Name,
                    DriverId = bus.DriverId,
                    NoOfTrips = bus.Trips.Count()
                };
                return busReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(BusAddDto busAddDto)
        {
            Bus bus = new Bus
            {
                Number = busAddDto.Number,
                Capacity = busAddDto.Capacity,
                CurrentBranch = busAddDto.CurrentBranch,
                Model = busAddDto.Model,
                Year = busAddDto.Year,
                BusClassId = busAddDto.BusClassId,
                DriverId = busAddDto.DriverId,
            };
            await _unitOfWork.BusRepo.AddAsync(bus);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, BusUpdateDto busUpdateDto)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdAsync(id);
            if (bus is not null)
            {
                bus.Number = busUpdateDto.Number;
                bus.Capacity = busUpdateDto.Capacity;
                bus.Available = busUpdateDto.Available;
                bus.CurrentBranch = busUpdateDto.CurrentBranch;
                bus.Model = busUpdateDto.Model;
                bus.Year = busUpdateDto.Year;
                bus.BusClassId = busUpdateDto.BusClassId;
                bus.DriverId = busUpdateDto.DriverId;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdAsync(id);
            if (bus is not null)
            {
                _unitOfWork.BusRepo.Delete(bus);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
