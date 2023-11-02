using GoBye.BLL.Dtos.TicketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TicketManagers
{
    public interface ITicketManager
    {
        Task<IEnumerable<TicketReadDto>?> GetAllWithReservationNumberAsync();
        Task<IEnumerable<TicketReadDto>?> GetAllByReservationIdAsync(int id);
        Task<IEnumerable<TicketReadDto>?> GetAllByTripIdAsync(int id);
        Task<TicketReadDto?> GetByIdWithReservationNumberAsync(int id);
        Task<bool> AddAsync(TicketAddDto ticketAddDto);
        Task<bool> UpdateAsync(int id, TicketUpdateDto ticketUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
