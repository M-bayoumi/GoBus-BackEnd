using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ReservationManagers
{
    public interface IReservationManager
    {
        Task<Response> GetAllWithTripDetailsAsync();
        Task<Response> GetAllByTripIdAsync(int id);
        Task<Response> GetAllWithTripDetailsByUserIdAsync(string id);
        Task<Response> GetByIdWithTripDetailsAsync(int id);
        Task<Response> AddAsync(ReservationAddDto reservationAddDto);
        Task<Response> DeleteAsync(int id);
    }
}
