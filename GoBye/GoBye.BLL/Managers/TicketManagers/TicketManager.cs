using GoBye.BLL.Dtos.TermDtos;
using GoBye.BLL.Dtos.TicketDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TicketManagers
{
    public class TicketManager : ITicketManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllWithReservationNumberAsync
        public async Task<Response> GetAllWithReservationNumberAsync()
        {
            IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllWithReservationNumberAsync();
            if (tickets is not null)
            {
                var data = tickets.Select(x => new TicketReadDto
                {
                    Id = x.Id,
                    SeatNumber = x.SeatNumber,
                    ReservationId = x.Reservation.Id,
                });
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Tickets");
        }
        #endregion


        #region GetAllByReservationIdAsync
        public async Task<Response> GetAllByReservationIdAsync(int id)
        {
            IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllByReservationIdAsync(id);
            if (tickets is not null)
            {
                var data = tickets.Select(x => new TicketReadDto
                {
                    Id = x.Id,
                    SeatNumber = x.SeatNumber,
                    ReservationId = x.Reservation.Id,
                });
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Tickets");
        }
        #endregion


        #region GetAllByTripIdAsync
        public async Task<Response> GetAllByTripIdAsync(int id)
        {
            IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllByTripIdAsync(id);
            if (tickets is not null)
            {
                var data = tickets.Select(x => new TicketReadDto
                {
                    Id = x.Id,
                    SeatNumber = x.SeatNumber,
                    ReservationId = x.Reservation.Id,
                });
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no Tickets");
        }
        #endregion


        #region GetByIdWithReservationNumberAsync
        public async Task<Response> GetByIdWithReservationNumberAsync(int id)
        {
            Ticket? ticket = await _unitOfWork.TicketRepo.GetByIdWithReservationNumberAsync(id);
            if (ticket is not null)
            {
                var data = new TicketReadDto
                {
                    Id = ticket.Id,
                    SeatNumber = ticket.SeatNumber,
                    ReservationId = ticket.Reservation.Id,
                };
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"Ticket is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(TicketAddDto ticketAddDto)
        {
            Ticket ticket = new Ticket
            {
                SeatNumber = ticketAddDto.SeatNumber,
                ReservationId = ticketAddDto.ReservationId,
            };
            await _unitOfWork.TicketRepo.AddAsync(ticket);
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Ticket has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Ticket");
        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(int id, TicketUpdateDto ticketUpdateDto)
        {
            Ticket? ticket = await _unitOfWork.TicketRepo.GetByIdAsync(id);

            if (ticket is not null)
            {
                ticket.SeatNumber = ticketUpdateDto.SeatNumber;
                ticket.ReservationId = ticketUpdateDto.ReservationId;
            }
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Destination has been updated successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to update Destination");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            Ticket? ticket = await _unitOfWork.TicketRepo.GetByIdAsync(id);
            if (ticket is not null)
            {
                _unitOfWork.TicketRepo.Delete(ticket);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The ticket has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete ticket");
            }
            return _unitOfWork.Response(false, null, $"ticket is not found");
        }
        #endregion
    }
}
