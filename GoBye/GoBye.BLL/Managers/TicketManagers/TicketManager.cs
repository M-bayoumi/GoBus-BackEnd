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
        public async Task<IEnumerable<TicketReadDto>?> GetAllWithReservationNumberAsync()
        {
            IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllWithReservationNumberAsync();
            if (tickets is not null)
            {
                return tickets.Select(x => new TicketReadDto
                {
                    Id = x.Id,
                    SeatNumber = x.SeatNumber,
                    ReservationNumber = x.Reservation.Number,
                });
            }

            return null;
        }
        #endregion


        #region GetAllByReservationIdAsync
        public async Task<IEnumerable<TicketReadDto>?> GetAllByReservationIdAsync(int id)
        {
            IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllByReservationIdAsync(id);
            if (tickets is not null)
            {
                return tickets.Select(x => new TicketReadDto
                {
                    Id = x.Id,
                    SeatNumber = x.SeatNumber,
                    ReservationNumber = x.Reservation.Number,
                });
            }

            return null;
        }
        #endregion


        #region GetAllByTripIdAsync
        public async Task<IEnumerable<TicketReadDto>?> GetAllByTripIdAsync(int id)
        {
            IEnumerable<Ticket>? tickets = await _unitOfWork.TicketRepo.GetAllByTripIdAsync(id);
            if (tickets is not null)
            {
                return tickets.Select(x => new TicketReadDto
                {
                    Id = x.Id,
                    SeatNumber = x.SeatNumber,
                    ReservationNumber = x.Reservation.Number,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdWithReservationNumberAsync
        public async Task<TicketReadDto?> GetByIdWithReservationNumberAsync(int id)
        {
            Ticket? ticket = await _unitOfWork.TicketRepo.GetByIdWithReservationNumberAsync(id);
            if (ticket is not null)
            {
                TicketReadDto ticketReadDto = new TicketReadDto
                {
                    Id = ticket.Id,
                    SeatNumber = ticket.SeatNumber,
                    ReservationNumber = ticket.Reservation.Number,
                };
                return ticketReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(TicketAddDto ticketAddDto)
        {
            Ticket ticket = new Ticket
            {
                SeatNumber = ticketAddDto.SeatNumber,
                ReservationId = ticketAddDto.ReservationId,
            };
            await _unitOfWork.TicketRepo.AddAsync(ticket);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, TicketUpdateDto ticketUpdateDto)
        {
            Ticket? ticket = await _unitOfWork.TicketRepo.GetByIdAsync(id);

            if (ticket is not null)
            {
                ticket.SeatNumber = ticketUpdateDto.SeatNumber;
                ticket.ReservationId = ticketUpdateDto.ReservationId;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Ticket? ticket = await _unitOfWork.TicketRepo.GetByIdAsync(id);
            if (ticket is not null)
            {
                _unitOfWork.TicketRepo.Delete(ticket);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
