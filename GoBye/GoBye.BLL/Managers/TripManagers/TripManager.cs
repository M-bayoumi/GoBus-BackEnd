using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Dtos.TripDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Hangfire;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoBye.BLL.Managers.TripManagers
{
    public class TripManager:ITripManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TripManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region FilterAllAsync
        public async Task<IEnumerable<TripReadDto>?> FilterAllAsync(TripSearchDto tripSearchDto)
        {
            IEnumerable<Trip>? trips = await _unitOfWork.TripRepo.FilterAllAsync();

            if (trips is not null)
            {
                IEnumerable<Trip>? filteredTrips = trips
                .Where(x => x.AvailableSeats >= tripSearchDto.Quantity)
                .Where(x => DateOnly.FromDateTime(x.DepartureDate) == DateOnly.Parse(tripSearchDto.DepartureDate))
                .Where(x => x.StartBranchId == tripSearchDto.StartBranchId)
                .Where(x => x.EndBranchId == tripSearchDto.EndBranchId)
                .ToList();

                return filteredTrips.Select(x => new TripReadDto
                {
                    Id = x.Id,
                    Quantity = tripSearchDto.Quantity,
                    AvailableSeats = x.Bus.Capacity,
                    DepartureDate = x.DepartureDate,
                    ArrivalDate = x.ArrivalDate,
                    BusClassName = x.Bus.BusClass.Name,
                    StartBranchName = x.StartBranch.Name,
                    EndBranchName = x.EndBranch.Name,
                    Price = x.Price,
                    TotalPrice = x.Price * tripSearchDto.Quantity,
                });
            }

            return null;
        }
        #endregion


        #region GetAllWithDetailsAsync
        public async Task<IEnumerable<TripDetailsDto>?> GetAllWithDetailsAsync()
        {
            IEnumerable<Trip>? trips = await _unitOfWork.TripRepo.GetAllWithDetailsAsync();
            if (trips is not null)
            {
                return trips.Select(x => new TripDetailsDto
                {
                    Id = x.Id,
                    AvailableSeats = x.AvailableSeats,
                    DepartureDate = x.DepartureDate,
                    ArrivalDate = x.ArrivalDate,
                    BusClassName = x.Bus.BusClass.Name,
                    StartBranchName = x.StartBranch.Name,
                    EndBranchName = x.EndBranch.Name,
                    Price = x.Price,
                    ReservationReadDtos = x.Reservations.Select(y => new ReservationReadDto
                    {
                        Id = y.Id,
                        Number = y.Number,
                        Quantity = y.Quantity,
                        TotalPrice = y.TotalPrice,
                        Date = y.Date,
                        UserId = y.UserId,
                        UserName = y.User.UserName!,
                        SeatNumbers = y.Tickets.Select(z => z.SeatNumber).ToList(),
                    }).ToList(),
                });
            }

            return null;
        }
        #endregion


        #region GetByIdWithBusClassNameAsync
        public async Task<TripUserDto?> GetByIdWithBusClassNameAsync(int id)
        {
            Trip? trip = await _unitOfWork.TripRepo.GetByIdWithBusClassNameAsync(id);

            if (trip is not null)
            {
                TripUserDto tripUserDto = new TripUserDto
                {

                    Id = trip.Id,
                    AvailableSeats = trip.AvailableSeats,
                    DepartureDate = trip.DepartureDate,
                    ArrivalDate = trip.ArrivalDate,
                    BusClassName = trip.Bus.BusClass.Name,
                    StartBranchName = trip.StartBranch.Name,
                    EndBranchName = trip.EndBranch.Name,
                    Price = trip.Price,
                };
                return tripUserDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(TripAddDto tripAddDto)
        {
            Trip trip = new Trip
            {
                DepartureDate = tripAddDto.DepartureDate,
                ArrivalDate = tripAddDto.ArrivalDate,
                Price = tripAddDto.Price,
                BusId = tripAddDto.BusId,
                StartBranchId = tripAddDto.StartBranchId,
                EndBranchId = tripAddDto.EndBranchId,
            };

            await _unitOfWork.TripRepo.AddAsync(trip);
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                Trip? tripDb = await _unitOfWork.TripRepo.GetByIdWithBusClassNameAsync(trip.Id);
                if(tripDb is not null)
                {
                    tripDb.AvailableSeats = tripDb.Bus.Capacity;
                    tripDb.Bus.CurrentBranch = "Enroute";
                    tripDb.Bus.Available = false;

                    BackgroundJob.Schedule(() => BusStatus(tripDb.BusId, tripDb.EndBranch.Name.ToString()), tripAddDto.ArrivalDate - tripAddDto.DepartureDate);

                }
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task BusStatus(int id, string currentBranch)
        {
            Bus? bus = await _unitOfWork.BusRepo.GetByIdAsync(id);
            bus!.Available = true;
            bus!.CurrentBranch = currentBranch;
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, TripUpdateDto tripUpdateDto)
        {
            Trip? trip = await _unitOfWork.TripRepo.GetByIdAsync(id);
            if (trip is not null)
            {
                trip.DepartureDate = tripUpdateDto.DepartureDate;
                trip.ArrivalDate = tripUpdateDto.ArrivalDate;
                trip.Price = tripUpdateDto.Price;
                trip.BusId = tripUpdateDto.BusId;
                trip.StartBranchId = tripUpdateDto.StartBranchId;
                trip.EndBranchId = tripUpdateDto.EndBranchId;

                bool result = await _unitOfWork.SaveChangesAsync() > 0;

                if (result)
                {
                    Trip? trip1 = await _unitOfWork.TripRepo.GetByIdWithBusClassNameAsync(trip.Id);
                    if (trip1 is not null)
                    {
                        trip1.AvailableSeats = trip1.Bus.Capacity;
                        return await _unitOfWork.SaveChangesAsync() > 0 || trip1!.AvailableSeats == trip1.Bus.Capacity; ;
                    }
                }
            }
            return await _unitOfWork.SaveChangesAsync() > 0 ;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Trip? trip = await _unitOfWork.TripRepo.GetByIdAsync(id);

            if (trip is not null)
            {
                _unitOfWork.TripRepo.Delete(trip);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
