using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoBye.BLL.Managers.ReservationManagers
{
    public class ReservationManager: IReservationManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithTripDetailsAsync
        public async Task<IEnumerable<ReservationDetailsDto>?> GetAllWithTripDetailsAsync()
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllWithTripDetailsAsync();
            if (reservations is not null)
            {
                return reservations.Select(x => new ReservationDetailsDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Price = x.Trip.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.Quantity * x.Trip.Price,
                    Date = x.Date,
                    UserId = x.UserId,
                    UserName = x.User.UserName!,
                    SeatNumbers = x.Tickets.Select(x=>x.SeatNumber).ToList(),
                    DepartureDate = x.Trip.DepartureDate,
                    ArrivalDate = x.Trip.ArrivalDate,
                    BusClassName = x.Trip.Bus.BusClass.Name,
                    StartBranchName = x.Trip.StartBranch.Name,
                    EndBranchName = x.Trip.EndBranch.Name,
                }).ToList();
            }

            return null;
        }
        #endregion


        #region GetAllByTripIdAsync
        public async Task<IEnumerable<ReservationReadDto>?> GetAllByTripIdAsync(int id)
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllByTripIdAsync(id);
            if (reservations is not null)
            {
                IEnumerable<ReservationReadDto>? reservationReadDtos = reservations.Select(x => new ReservationReadDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Price = x.Trip.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.TotalPrice,
                    Date = x.Date,
                    UserId = x.UserId,
                    UserName = x.User.UserName!,
                    PhoneNumber = x.User.PhoneNumber!,
                    SeatNumbers = x.Tickets.Select(x => x.SeatNumber).ToList(),
                }).ToList();

                return reservationReadDtos;
            }

            return null;
        }
        #endregion


        #region GetAllWithTripDetailsByUserIdAsync
        public async Task<IEnumerable<ReservationDetailsDto>?> GetAllWithTripDetailsByUserIdAsync(string id)
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllWithTripDetailsByUserIdAsync(id);
            if (reservations is not null)
            {
                return reservations.Select(x => new ReservationDetailsDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Price = x.Trip.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.TotalPrice,
                    Date = x.Date,
                    UserId = x.UserId,
                    UserName = x.User.UserName!,
                    SeatNumbers = x.Tickets.Select(x => x.SeatNumber).ToList(),
                    DepartureDate = x.Trip.DepartureDate,
                    ArrivalDate = x.Trip.ArrivalDate,
                    BusClassName = x.Trip.Bus.BusClass.Name,
                    StartBranchName = x.Trip.StartBranch.Name,
                    EndBranchName = x.Trip.EndBranch.Name,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdWithTripDetailsAsync
        public async Task<ReservationDetailsDto?> GetByIdWithTripDetailsAsync(int id)
        {
            Reservation? reservation = await _unitOfWork.ReservationRepo.GetByIdWithTripDetailsAsync(id);
            if (reservation is not null)
            {
                ReservationDetailsDto reservationDetailsDto = new ReservationDetailsDto
                {
                    Id = reservation.Id,
                    Number = reservation.Number,
                    Quantity = reservation.Quantity,
                    TotalPrice = reservation.TotalPrice,
                    Date = reservation.Date,
                    UserId = reservation.UserId,
                    UserName = reservation.User.UserName!,
                    SeatNumbers = reservation.Tickets.Select(x => x.SeatNumber).ToList(),
                    DepartureDate = reservation.Trip.DepartureDate,
                    ArrivalDate = reservation.Trip.ArrivalDate,
                    BusClassName = reservation.Trip.Bus.BusClass.Name,
                    StartBranchName = reservation.Trip.StartBranch.Name,
                    EndBranchName = reservation.Trip.EndBranch.Name,
                };
                return reservationDetailsDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(ReservationAddDto reservationAddDto)
        {
            Reservation reservation = new Reservation
            {
                Number = reservationAddDto.Number,
                Quantity = reservationAddDto.Quantity,
                Date = reservationAddDto.Date,
                UserId = reservationAddDto.UserId,
                TripId = reservationAddDto.TripId,
            };

            await _unitOfWork.ReservationRepo.AddAsync(reservation);

            bool result = await _unitOfWork.SaveChangesAsync() > 0;

            Trip? trip = await _unitOfWork.TripRepo.GetByIdAsync(reservation.TripId);

            if(trip is not null)
            {
                reservation.TotalPrice = reservation.Quantity * trip.Price;
                reservation.Price = trip.Price;
                await _unitOfWork.SaveChangesAsync();

                if (result && reservationAddDto.Quantity == reservationAddDto.SeatNumbers.Count())
                {
                    foreach (int seatNumber in reservationAddDto.SeatNumbers)
                    {
                        IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllByTripIdAsync(trip.Id);

                        if (tickets is not null && tickets.Any(x=>x.SeatNumber != seatNumber))
                        {
                            await _unitOfWork.TicketRepo.AddAsync(new Ticket { SeatNumber = seatNumber, ReservationId = reservation.Id });

                            trip.AvailableSeats--;
                        }
                    }
                    return await _unitOfWork.SaveChangesAsync() > 0;
                }
            }
            
            _unitOfWork.ReservationRepo.Delete(reservation);
            await _unitOfWork.SaveChangesAsync();
            return false;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Reservation? reservation = await _unitOfWork.ReservationRepo.GetByIdAsync(id);
            if (reservation is not null)
            {
                _unitOfWork.ReservationRepo.Delete(reservation);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
