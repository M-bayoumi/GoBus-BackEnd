using GoBye.BLL.Dtos.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ReservationManagers
{
    public interface IReservationManager
    {
        Task<IEnumerable<ReservationDetailsDto>?> GetAllWithTripDetailsAsync();
        Task<IEnumerable<ReservationReadDto>?> GetAllByTripIdAsync(int id);
        Task<IEnumerable<ReservationDetailsDto>?> GetAllWithTripDetailsByUserIdAsync(string id);
        Task<ReservationDetailsDto?> GetByIdWithTripDetailsAsync(int id);
        Task<bool> AddAsync(ReservationAddDto reservationAddDto);
        Task<bool> DeleteAsync(int id);
    }
}
