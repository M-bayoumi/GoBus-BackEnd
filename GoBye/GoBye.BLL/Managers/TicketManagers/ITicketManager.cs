using GoBye.BLL.Dtos.TicketDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TicketManagers
{
    public interface ITicketManager
    {
        Task<Response> GetAllWithReservationNumberAsync();
        Task<Response> GetAllByReservationIdAsync(int id);
        Task<Response> GetAllByTripIdAsync(int id);
        Task<Response> GetByIdWithReservationNumberAsync(int id);
        Task<Response> AddAsync(TicketAddDto ticketAddDto);
        Task<Response> UpdateAsync(int id, TicketUpdateDto ticketUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
