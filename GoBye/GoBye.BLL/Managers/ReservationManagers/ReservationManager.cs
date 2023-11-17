using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Dtos.TripDtos;
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
        public async Task<Response> GetAllWithTripDetailsAsync()
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllWithTripDetailsAsync();
            if (reservations is not null)
            {
                var data = reservations.Select(x => new ReservationDetailsDto
                {
                    Id = x.Id,
                    Price = x.Trip.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.Quantity * x.Trip.Price,
                    Date = x.Date,
                    TripId =x.TripId,
                    UserId = x.UserId,
                    UserName = x.User.UserName!,
                    SeatNumbers = x.Tickets.Select(x=>x.SeatNumber).ToList(),
                    DepartureDate = x.Trip.DepartureDate,
                    ArrivalDate = x.Trip.ArrivalDate,
                    BusClassName = x.Trip.Bus.BusClass.Name,
                    StartBranchName = x.Trip.StartBranch.Name,
                    EndBranchName = x.Trip.EndBranch.Name,
                }).ToList();

                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Reservations");
        }
        #endregion

        #region FilterByDateAsync
        public async Task<Response> FilterByDateAsync(DateOnly date)
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllWithTripDetailsAsync();
            if (reservations is not null)
            {
                IEnumerable<Reservation>? filteredReservations = reservations
                .Where(x => DateOnly.FromDateTime(x.Date) == date)
                .ToList();
                var data = filteredReservations.Select(x => new ReservationDetailsDto
                {
                    Id = x.Id,
                    Price = x.Trip.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.Quantity * x.Trip.Price,
                    Date = x.Date,
                    TripId = x.TripId,
                    UserId = x.UserId,
                    UserName = x.User.UserName!,
                    SeatNumbers = x.Tickets.Select(x => x.SeatNumber).ToList(),
                    DepartureDate = x.Trip.DepartureDate,
                    ArrivalDate = x.Trip.ArrivalDate,
                    BusClassName = x.Trip.Bus.BusClass.Name,
                    StartBranchName = x.Trip.StartBranch.Name,
                    EndBranchName = x.Trip.EndBranch.Name,
                }).ToList();

                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Reservations");
        }

        #endregion



        #region GetAllByTripIdAsync
        public async Task<Response> GetAllByTripIdAsync(int id)
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllByTripIdAsync(id);
            if (reservations is not null)
            {
                var data = reservations.Select(x => new ReservationReadDto
                {
                    Id = x.Id,
                    Price = x.Trip.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.TotalPrice,
                    Date = x.Date,
                    UserId = x.UserId,
                    UserName = x.User.UserName!,
                    PhoneNumber = x.User.PhoneNumber!,
                    SeatNumbers = x.Tickets.Select(x => x.SeatNumber).ToList(),
                }).ToList();

                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Reservations");
        }
        #endregion


        #region GetAllWithTripDetailsByUserIdAsync
        public async Task<Response> GetAllWithTripDetailsByUserIdAsync(string id)
        {
            IEnumerable<Reservation>? reservations = await _unitOfWork.ReservationRepo.GetAllWithTripDetailsByUserIdAsync(id);
            if (reservations is not null)
            {
                var data = reservations.Select(x => new ReservationDetailsDto
                {
                    Id = x.Id,
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
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Reservations");
        }
        #endregion


        #region GetByIdWithTripDetailsAsync
        public async Task<Response> GetByIdWithTripDetailsAsync(int id)
        {
            Reservation? reservation = await _unitOfWork.ReservationRepo.GetByIdWithTripDetailsAsync(id);
            if (reservation is not null)
            {
                var data = new ReservationDetailsDto
                {
                    Id = reservation.Id,
                    Price = reservation.Price,
                    Quantity = reservation.Quantity,
                    TotalPrice = reservation.TotalPrice,
                    Date = reservation.Date,
                    UserId = reservation.UserId,
                    UserName = reservation.User.UserName!,
                    FirstName = reservation.User.FirstName!,
                    LastName = reservation.User.LastName!,
                    Email = reservation.User.Email!,
                    SeatNumbers = reservation.Tickets.Select(x => x.SeatNumber).ToList(),
                    DepartureDate = reservation.Trip.DepartureDate,
                    ArrivalDate = reservation.Trip.ArrivalDate,
                    BusClassName = reservation.Trip.Bus.BusClass.Name,
                    BusNumber = reservation.Trip.Bus.Number,
                    StartBranchName = reservation.Trip.StartBranch.Name,
                    EndBranchName = reservation.Trip.EndBranch.Name,
                };
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"Reservation is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(ReservationAddDto reservationAddDto)
        {
            Reservation reservation = new Reservation
            {
                Quantity = reservationAddDto.Quantity,
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
                    IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllByTripIdAsync(trip.Id);
                    IEnumerable<int>? seatNumbers = tickets?.Select(x=>x.SeatNumber).ToList();

                    foreach (int seatNumber in reservationAddDto.SeatNumbers)
                    {
                        if (seatNumbers is not null && !seatNumbers.Any(x => x == seatNumber))
                        {
                            await _unitOfWork.TicketRepo.AddAsync(new Ticket { SeatNumber = seatNumber, ReservationId = reservation.Id });

                            trip.AvailableSeats--;
                        }
                    }
                    bool addTickets = await _unitOfWork.SaveChangesAsync() > 0;
                    if (addTickets)
                    {
                        return _unitOfWork.Response(true, reservation.Id, "The Reservation has been added successfully");
                    }
                }
            }
            
            _unitOfWork.ReservationRepo.Delete(reservation);
            await _unitOfWork.SaveChangesAsync();

            return _unitOfWork.Response(false, null, "Failed to add Reservation");

        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            Reservation? reservation = await _unitOfWork.ReservationRepo.GetByIdAsync(id);
            if (reservation is not null)
            {
                _unitOfWork.ReservationRepo.Delete(reservation);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Reservation has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Reservation");
            }
            return _unitOfWork.Response(false, null, $"Reservation is not found");
        }
        #endregion
    }
}
