using GoBye.BLL.Dtos.BusDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<Response> GetAllWithBusClassAsync()
        {
            IEnumerable<Bus>? buses = await _unitOfWork.BusRepo.GetAllWithBusClassAsync();
            if (buses is not null)
            {
                var data = buses.Select(x => new BusReadDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Capacity = x.Capacity,
                    Available = x.Available,
                    CurrentBranch = x.CurrentBranch,
                    Model = x.Model,
                    Year = x.Year,
                    ClassBusName = x.BusClass.Name,
                    ClassBusId = x.BusClass.Id,
                    DriverId = x.DriverId,
                    DriverFirstName= x.Driver.FirstName,
                    DriverLastName= x.Driver.LastName,
                    NoOfTrips = x.Trips.Count()
                });
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no Buses");
        }
        #endregion


        #region GetAllByBusClassIdAsync
        public async Task<Response> GetAllByBusClassIdAsync(int id)
        {
            IEnumerable<Bus>? buses = await _unitOfWork.BusRepo.GetAllByBusClassIdAsync(id);
            if (buses is not null)
            {
                var data = buses.Select(x => new BusReadDto
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
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no Buses");
        }
        #endregion


        #region GetAllAvailableBusesAsync
        public async Task<Response> GetAllAvailableBusesAsync(DateTime departureDate, DateTime arrivalDate)
        {
            IEnumerable<Bus>? buses = await _unitOfWork.BusRepo.GetAllAvailableBusesAsync();
            List<Bus> avaBuses = new List<Bus>();

            if (buses is not null)
            {
                foreach (var bus in buses)
                {
                    bool isAvailable = true;

                    if (bus.Trips != null && bus.Trips.Any())
                    {
                        foreach (var trip in bus.Trips)
                        {
                            if (!((departureDate < trip.DepartureDate && arrivalDate < trip.DepartureDate) || (departureDate > trip.ArrivalDate && arrivalDate > trip.ArrivalDate)))
                            {
                                isAvailable = false; 
                                break;
                            }
                        }
                    }

                    if (isAvailable)
                    {
                        avaBuses.Add(bus);
                    }
                }

                var data = avaBuses.Select(x => new BusAvailableDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Available = x.Available,
                    CurrentBranch = x.CurrentBranch,
                    ClassBusName = x.BusClass.Name,
                });

                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no Available Buses");
        }
        #endregion


        #region GetByIdWithBusClassAsync
        public async Task<Response> GetByIdWithBusClassAsync(int id)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdWithBusClassAsync(id);
            if (bus is not null)
            {
                var data = new BusReadDto
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
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"Bus is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(BusAddDto busAddDto)
        {
            Bus bus = new Bus
            {
                Number = busAddDto.Number,
                Capacity = busAddDto.Capacity,
                Model = busAddDto.Model,
                Year = busAddDto.Year,
                BusClassId = busAddDto.BusClassId,
                DriverId = busAddDto.DriverId,
            };
            await _unitOfWork.BusRepo.AddAsync(bus);

            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Bus has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Bus");
        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(int id, BusUpdateDto busUpdateDto)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdAsync(id);
            if (bus is not null)
            {
                bus.Number = busUpdateDto.Number;
                bus.Capacity = busUpdateDto.Capacity;
                bus.CurrentBranch = busUpdateDto.CurrentBranch;
                bus.Model = busUpdateDto.Model;
                bus.Year = busUpdateDto.Year;
                bus.BusClassId = busUpdateDto.BusClassId;
                bus.DriverId = busUpdateDto.DriverId;
            }
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Bus has been updated successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to update Bus");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdAsync(id);

            if (bus is not null)
            {
                _unitOfWork.BusRepo.Delete(bus);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Bus has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Bus");
            }
            return _unitOfWork.Response(false, null, $"Bus is not found");
        }
        #endregion
    }
}
